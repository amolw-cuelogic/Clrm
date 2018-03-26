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
    templateUrl: 'editemployee.component.html'
})
export class EditEmployeeComponent {
   
    id: number;
    mode: string;
    baseUrl: string;
    pageObject: any = new Object({
        Employee: new Object({
            EmployeeSkillList: [],
            IdentityEmployeeGroupList: [],
            EmployeeOrganizationRoleList: [],
            EmployeeDepartmentList: []
        }),
        IdentityGroupList: [],
        MasterDepartmentList: [],
        MasterOrganizationRoleList: [],
        MasterSkillList: []
    });
    loaded: boolean = false;
    apiController: string = "api/Employee";

    disabled = false;

    ngAfterContentInit() {
        this.actroute.params.subscribe(params => {
            this.id = +params['id'];
            this.mode = params['mode'];
            this.LoadEditPage(this.id);
        });
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
                if (this.mode == this.formMode.Edit) {
                    this.LoadEditPage(this.id);
                    var model = new BootstrapModel();
                    model.Title = "Saved";
                    model.MessageType = model.ModelType.Success;
                    model.Message = "Saved Successfully";
                    this.compSubSrv.OpenToaster(model);
                }
                else {
                    this.router.navigate(["/employee"]);
                    var model = new BootstrapModel();
                    model.Title = "Saved";
                    model.MessageType = model.ModelType.Success;
                    model.Message = "Saved Successfully";
                    this.compSubSrv.OpenToaster(model);
                }
            }
        );
    }


    LoadEditPage(id: any) {
        this.httpClient.get(this.baseUrl + this.apiController + "/" + id
        ).subscribe(
            m => {
                this.pageObject = m;
                this.serviceAppConfig.AdjustBottomHeight();
                this.LoadMasterList(id);
                if (this.mode == this.formMode.View) {
                    this.SetFormModeView();
                }
            }
            );
    }

    LoadMasterList(id: any) {
        this.httpClient.get(this.baseUrl + this.apiController + "/GetMasterList"
        ).subscribe(
            m => {
                this.pageObject.IdentityGroupList = m["IdentityGroupList"];
                this.pageObject.MasterDepartmentList = m["MasterDepartmentList"];
                this.pageObject.MasterOrganizationRoleList = m["MasterOrganizationRoleList"];
                this.pageObject.MasterSkillList = m["MasterSkillList"];
            }
            );
    }

    constructor(private httpClient: HttpClient, private serviceAppConfig: AppconfigService,
        private actroute: ActivatedRoute, private formMode: FormMode, private compSubSrv: ComponentSubscriptionService,
        private router: Router, private commonService: CommonService) {
        this.baseUrl = this.serviceAppConfig.GetBaseUrl();

    }


    CloseModal(id: any) {
        this.commonService.HideBootstrapModal(id);
    }

    //SKILL Modal

    OpenSkillModal(id: any) {
        $('#idDivModalCollection input:checkbox').closest('tr').show();
        $('#idDivModalCollection #' + id + ' input:checkbox').each(function () {
            if ($(this).is(":checked"))
                $(this).trigger('click');
        });

        for (var i = 0; i < this.pageObject.Employee.EmployeeSkillList.length; i++) {
            var item = this.pageObject.Employee.EmployeeSkillList[i];
            var SkillId = item.SkillId;
            $('#idDivModalCollection input:checkbox[data-s-id="' + SkillId + '"]').closest('tr').hide();
        }

        this.commonService.ShowBootstrapModal(id);
    }

    AddSkills(id: any) {
        var indexArray = [];
        $('#idDivModalCollection #' + id + ' input:checkbox').each(function () {
            if ($(this).is(":checked")) {
                var index = $(this).attr('data-s-index');
                indexArray.push(index);
            }
        });

        for (var i = 0; i < indexArray.length; i++) {
            var masterSkill = this.pageObject.MasterSkillList[indexArray[i]];
            var employeeSkill = new Object({
                Id:0,
                EmployeeId: this.pageObject.Employee.Id,
                SkillId: masterSkill.Id,
                IsValid: true,
                SkillName: masterSkill.Skill
            });
            this.pageObject.Employee.EmployeeSkillList.push(employeeSkill);
        }
        this.commonService.HideBootstrapModal(id);
    }

    RemoveSkill(id: any) {
        this.pageObject.Employee.EmployeeSkillList.splice(id, 1);
    }


    //GROUP Modal

    OpenGroupModal(id: any) {
        $('#idDivModalCollection input:checkbox').closest('tr').show();
        $('#idDivModalCollection #' + id + ' input:checkbox').each(function () {
            if ($(this).is(":checked"))
                $(this).trigger('click');
        });

        for (var i = 0; i < this.pageObject.Employee.IdentityEmployeeGroupList.length; i++) {
            var item = this.pageObject.Employee.IdentityEmployeeGroupList[i];
            var GroupId = item.GroupId;
            $('#idDivModalCollection input:checkbox[data-s-id="' + GroupId + '"]').closest('tr').hide();
        }

        this.commonService.ShowBootstrapModal(id);
    }

    AddGroups(id: any) {
        var indexArray = [];
        $('#idDivModalCollection #' + id + ' input:checkbox').each(function () {
            if ($(this).is(":checked")) {
                var index = $(this).attr('data-s-index');
                indexArray.push(index);
            }
        });

        for (var i = 0; i < indexArray.length; i++) {
            var masterGroup = this.pageObject.IdentityGroupList[indexArray[i]];
            var employeeGroup = new Object({
                Id:0,
                EmployeeId: this.pageObject.Employee.Id,
                GroupId: masterGroup.Id,
                IsValid: true,
                GroupName: masterGroup.GroupName
            });
            this.pageObject.Employee.IdentityEmployeeGroupList.push(employeeGroup);
        }
        this.commonService.HideBootstrapModal(id);
    }

    RemoveGroup(id: any) {
        this.pageObject.Employee.IdentityEmployeeGroupList.splice(id, 1);
    }

    //Oganization  Modal

    OpenOganizationRoleModal(id: any) {
        $('#idDivModalCollection input:checkbox').closest('tr').show();
        $('#idDivModalCollection #' + id + ' input:checkbox').each(function () {
            if ($(this).is(":checked"))
                $(this).trigger('click');
        });
        for (var i = 0; i < this.pageObject.Employee.EmployeeOrganizationRoleList.length; i++) {
            var item = this.pageObject.Employee.EmployeeOrganizationRoleList[i];
            var RoleId = item.RoleId;
            $('#idDivModalCollection input:checkbox[data-s-id="' + RoleId + '"]').closest('tr').hide();
        }

        this.commonService.ShowBootstrapModal(id);
    }

    AddOganizationRoles(id: any) {
        var indexArray = [];
        $('#idDivModalCollection #' + id + ' input:checkbox').each(function () {
            if ($(this).is(":checked")) {
                var index = $(this).attr('data-s-index');
                indexArray.push(index);
            }
        });

        for (var i = 0; i < indexArray.length; i++) {
            var masterOrganizationRole = this.pageObject.MasterOrganizationRoleList[indexArray[i]];
            var employeeGroup = new Object({
                Id:0,
                EmployeeId: this.pageObject.Employee.Id,
                RoleId: masterOrganizationRole.Id,
                IsValid: true,
                RoleName: masterOrganizationRole.Role
            });
            this.pageObject.Employee.EmployeeOrganizationRoleList.push(employeeGroup);
        }
        this.commonService.HideBootstrapModal(id);
    }

    RemoveOrganizationRole(id: any) {
        this.pageObject.Employee.EmployeeOrganizationRoleList.splice(id, 1);
    }

    //Department  Modal

    OpenDepartmentModal(id: any) {
        $('#idDivModalCollection input:checkbox').closest('tr').show();
        $('#idDivModalCollection #' + id + ' input:checkbox').each(function () {
            if ($(this).is(":checked"))
                $(this).trigger('click');
        });
        for (var i = 0; i < this.pageObject.Employee.EmployeeDepartmentList.length; i++) {
            var item = this.pageObject.Employee.EmployeeDepartmentList[i];
            var DepartmentId = item.DepartmentId;
            $('#idDivModalCollection input:checkbox[data-s-id="' + DepartmentId + '"]').closest('tr').hide();
        }

        this.commonService.ShowBootstrapModal(id);
    }

    AddDepartments(id: any) {
        var indexArray = [];
        $('#idDivModalCollection #' + id + ' input:checkbox').each(function () {
            if ($(this).is(":checked")) {
                var index = $(this).attr('data-s-index');
                indexArray.push(index);
            }
        });

        for (var i = 0; i < indexArray.length; i++) {
            var masterMasterDepartmentList = this.pageObject.MasterDepartmentList[indexArray[i]];
            var employeeDepartment = new Object({
                Id: 0,
                EmployeeId: this.pageObject.Employee.Id,
                DepartmentId: masterMasterDepartmentList.Id,
                IsValid: true,
                DepartmentName: masterMasterDepartmentList.DepartmentName
            });
            this.pageObject.Employee.EmployeeDepartmentList.push(employeeDepartment);
        }
        this.commonService.HideBootstrapModal(id);
    }

    RemoveDepartment(id: any) {
        this.pageObject.Employee.EmployeeDepartmentList.splice(id, 1);
    }
}


