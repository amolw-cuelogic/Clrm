import { Component, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AppconfigService } from '../../../service/appconfig.service'
import * as $ from 'jquery'
import { ActivatedRoute } from '@angular/router'
import { FormMode } from '../../../model/FormMode';
import { BootstrapModel } from '../../../model/bootstrapmodel'
import { ComponentSubscriptionService } from '../../../service/componentsubscription.service'
import { CommonService } from '../../../service/common.service'
import { Router } from '@angular/router'

@Component({
    templateUrl: 'usergroup.component.html'
})
export class UserGroupComponent {

    id: number;
    mode: string;
    baseUrl: string;
    pageObject: any = new Object({
        GroupList: [],
        EmployeeList: [],
        GroupMemberList: []
    });
    GroupId: any = 0;
    filterText: any;

    monitorList: any = [];

    apiController: string = "api/Usergroup";

    disabled = false;

    ngAfterContentInit() {
        this.LoadGroupsDropdown();
        this.LoadEmployeeList();
    }

    DropDownChange(id: any) {
        this.httpClient.get(this.baseUrl + this.apiController + "/groupmembers/" + id
        ).subscribe(
            m => {
                this.pageObject.GroupMemberList = m;
                this.serviceAppConfig.AdjustBottomHeight();
                this.RefreshEmployeeList();
            }
            );
    }

    SetFormModeView() {
        this.disabled = true;
        $('.dynamicBottomDiv input,.dynamicBottomDiv textarea,input[type="checkbox"]').attr("disabled", "true");
    }

    SaveGroup() {

        if (this.pageObject.GroupMemberList.length == 0)
        {
            var model = new BootstrapModel();
            model.Title = "Warning";
            model.MessageType = model.ModelType.Warning;
            model.Message = "Please add atleast one employee in group.";
            this.compSubSrv.OpenBootstrapModal(model);
            return false;
        }

        var identityGroupList = [];
        var data = this.pageObject.GroupMemberList;
        for (var i = 0; i < data.length; i++) {
            var igObject = new Object({
                GroupId: this.GroupId,
                EmployeeId: data[i].Id,
                IsValid:true
            });
            identityGroupList.push(igObject);
        }

        var da = JSON.stringify(identityGroupList);
        let headers = new HttpHeaders().set('Content-Type', 'application/json');

        this.httpClient.post(this.baseUrl + this.apiController, da, { headers: headers }).subscribe(
            m => {
                var model = new BootstrapModel();
                model.Title = "Saved";
                model.MessageType = model.ModelType.Success;
                model.Message = "Saved Successfully";
                this.compSubSrv.OpenBootstrapModal(model);
            }
        );
    }

    SearchFilter() {
        this.LoadEmployeeList();
    }

    ClearFilter() {
        this.filterText = "";
        this.SearchFilter();
    }

    LoadGroupsDropdown() {
        this.httpClient.get(this.baseUrl + this.apiController + "/groups"
        ).subscribe(
            m => {
                this.pageObject.GroupList = m;
                this.serviceAppConfig.AdjustBottomHeight();
            }
            );
    }

    LoadEmployeeList() {
        this.httpClient.get(this.baseUrl + this.apiController + "/employees?employeeName=" + this.filterText
        ).subscribe(
            m => {
                this.pageObject.EmployeeList = m;
                this.serviceAppConfig.AdjustBottomHeight();
                this.RefreshEmployeeList();
            }
            );
    }


    constructor(private httpClient: HttpClient, private serviceAppConfig: AppconfigService,
        private actroute: ActivatedRoute, private formMode: FormMode, private compSubSrv: ComponentSubscriptionService,
        private router: Router, private commonService: CommonService) {
        this.baseUrl = this.serviceAppConfig.GetBaseUrl();
        this.filterText = "";
    }

    RemoveEmployeeItem(employeeId: any) {
        var id = 0;
        var empLength = this.pageObject.EmployeeList.length;
        for (var i = 0; i < empLength; i++) {
            if (this.pageObject.EmployeeList[i].Id == employeeId) {
                id = i;
                break;
            }
        }
        this.pageObject.EmployeeList.splice(i, 1);
    }


    AddEmployeeToGroup() {
        var obj = [];
        var empLength = this.pageObject.EmployeeList.length;
        for (var i = 0; i < empLength; i++) {
            if (this.pageObject.EmployeeList[i].IsValid == true) {
                this.pageObject.EmployeeList[i].IsValid = false;
                obj.push(this.pageObject.EmployeeList[i]);
                this.monitorList.push(this.pageObject.EmployeeList[i]);
                this.pageObject.GroupMemberList.push(this.pageObject.EmployeeList[i]);
            }
        }

        for (var i = 0; i < obj.length; i++) {
            this.RemoveEmployeeItem(obj[i].Id);
        }
    }

    RemoveMonitorListItem(employeeId: any) {
        var id = 0;
        var length = this.monitorList.length;
        for (var i = 0; i < length; i++) {
            if (this.monitorList[i].Id == employeeId) {
                id = i;
                break;
            }
        }
        this.monitorList.splice(i, 1);
    }

    RemoveGroupItem(employeeId: any) {
        var id = 0;
        var length = this.pageObject.GroupMemberList.length;
        for (var i = 0; i < length; i++) {
            if (this.pageObject.GroupMemberList[i].Id == employeeId) {
                id = i;
                break;
            }
        }
        this.pageObject.GroupMemberList.splice(i, 1);
    }

    RemoveGroupMember() {
        var obj = [];
        var grpMemberLength = this.pageObject.GroupMemberList.length;
        for (var i = 0; i < grpMemberLength; i++) {
            if (this.pageObject.GroupMemberList[i].IsValid == true) {
                this.pageObject.GroupMemberList[i].IsValid = false;
                obj.push(this.pageObject.GroupMemberList[i]);
                this.pageObject.EmployeeList.push(this.pageObject.GroupMemberList[i]);
                this.RemoveMonitorListItem(this.pageObject.GroupMemberList[i].Id);
            }
        }
        for (var i = 0; i < obj.length; i++) {
            this.RemoveGroupItem(obj[i].Id);
        }
    }

    RefreshEmployeeList() {
        for (var i = 0; i < this.monitorList.length; i++) {
            this.monitorList.IsValid = false;
            var count = 0;
            for (var j = 0; j < this.pageObject.EmployeeList.length; j++) {
                if (this.pageObject.EmployeeList[j].Id == this.monitorList[i].Id)
                    count++;
            }
            if (count == 0)
                this.pageObject.EmployeeList.push(this.monitorList[i]);

        }
        this.monitorList = [];
        for (var i = 0; i < this.pageObject.GroupMemberList.length; i++) {
            var groupMember = this.pageObject.GroupMemberList[i];

            for (var j = 0; j < this.pageObject.EmployeeList.length; j++) {
                if (this.pageObject.EmployeeList[j].Id == groupMember.Id) {
                    var obj = new Object({
                        Id: groupMember.Id,
                        FullName: groupMember.FullName,
                        IsValid: false
                    });
                    this.monitorList.push(obj);

                    this.pageObject.EmployeeList.splice(j, 1);
                }
            }
        }
    }

}


