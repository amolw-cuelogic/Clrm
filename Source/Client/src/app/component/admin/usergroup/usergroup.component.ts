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

    tempList: any = [];

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
        var da = JSON.stringify(this.pageObject);
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

    AddEmployeeToGroup() {
        var obj = [];
        for (var i = 0; i < this.pageObject.EmployeeList.length; i++) {
            if (this.pageObject.EmployeeList[i].IsValid == true) {
                this.pageObject.EmployeeList[i].IsValid = false;
                obj.push(i);
                this.tempList.push(this.pageObject.EmployeeList[i]);
                this.pageObject.GroupMemberList.push(this.pageObject.EmployeeList[i]);
            }
        }
        //this.pageObject.GroupMemberList.push(obj);
        for (var i = 0; i < obj.length; i++) {
            this.pageObject.EmployeeList.splice(obj[i],1);
        }
    }

    RefreshEmployeeList() {
        for (var i = 0; i < this.tempList.length; i++) {

            var count = 0;
            for (var j = 0; j < this.pageObject.EmployeeList.length; j++) {
                if (this.pageObject.EmployeeList[j].Id == this.tempList[i].Id)
                    count++;
            }
            if (count == 0)
                this.pageObject.EmployeeList.push(this.tempList[i]);

        }
        this.tempList = [];
        for (var i = 0; i < this.pageObject.GroupMemberList.length; i++) {
            var groupMember = this.pageObject.GroupMemberList[i];

            for (var j = 0; j < this.pageObject.EmployeeList.length; j++) {
                if (this.pageObject.EmployeeList[j].Id == groupMember.Id) {
                    var obj = new Object({
                        Id: groupMember.Id,
                        FullName: groupMember.FullName,
                        IsValid: false
                    });
                    this.tempList.push(obj);

                    this.pageObject.EmployeeList.splice(j, 1);
                }
            }
        }

    }

}


