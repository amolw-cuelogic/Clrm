import { Component, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AppconfigService } from '../../service/appconfig.service'
import * as $ from 'jquery'
import { ActivatedRoute } from '@angular/router'
import { FormMode } from '../../model/FormMode';
import { BootstrapModel } from '../../model/bootstrapmodel'
import { ComponentSubscriptionService } from '../../service/componentsubscription.service'
import { CommonService } from '../../service/common.service'
import { Router } from '@angular/router'

@Component({
    templateUrl: 'editmyprofile.component.html'
})
export class EditMyProfileComponent {
 
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
    pageList: any;
    loaded: boolean = false;
    apiController: string = "api/MyProfile";

    disabled = false;

    ngAfterContentInit() {
        this.actroute.params.subscribe(params => {
            this.LoadEditPage();
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
                var model = new BootstrapModel();
                model.Title = "Saved";
                model.MessageType = model.ModelType.Success;
                model.Message = "Saved Successfully";
                this.compSubSrv.OpenBootstrapModal(model);
                this.LoadEditPage();
            }
        );
    }


    LoadEditPage() {
        this.httpClient.get(this.baseUrl + this.apiController + "/"
        ).subscribe(
            m => {
                this.pageObject = m["employeeVm"];
                this.pageList = JSON.parse(m["employeeAllocation"]);
                this.serviceAppConfig.AdjustBottomHeight();

            }
            );
    }


    constructor(private httpClient: HttpClient, private serviceAppConfig: AppconfigService,
        private actroute: ActivatedRoute, private formMode: FormMode, private compSubSrv: ComponentSubscriptionService,
        private router: Router, private commonService: CommonService) {
        this.baseUrl = this.serviceAppConfig.GetBaseUrl();

    }


}


