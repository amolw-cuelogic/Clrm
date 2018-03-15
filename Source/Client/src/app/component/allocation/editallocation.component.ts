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
    templateUrl: 'editallocation.component.html'
})
export class EditAllocationComponent {

    id: number;
    mode: string;
    baseUrl: string;
    pageObject: any = new Object({
        SelectListMasterRole: []
    });
    ProjectRoleMessage: boolean = false;
    loaded: boolean = false;
    apiController: string = "api/EmployeeAllocation";
    allocationPercentageError: any;
    validForm: any;

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
        $('.dynamicBottomDiv input,.dynamicBottomDiv textarea,input[type="checkbox"], select').attr("disabled", "true");
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
                    this.router.navigate(["/allocation"]);
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

                if (m["EmployeeId"] == 0)
                    m["EmployeeId"] = null;
                if (m["ProjectRoleId"] == 0)
                    m["ProjectRoleId"] = null;
                if (m["ProjectId"] == 0)
                    m["ProjectId"] = null;
                this.pageObject = m;
                this.serviceAppConfig.AdjustBottomHeight();
                if (this.mode == this.formMode.View) {
                    this.SetFormModeView();
                }
                this.ValidateAllocation();
            }
            );
    }


    constructor(private httpClient: HttpClient, private serviceAppConfig: AppconfigService,
        private actroute: ActivatedRoute, private formMode: FormMode, private compSubSrv: ComponentSubscriptionService,
        private router: Router, private commonService: CommonService) {
        this.baseUrl = this.serviceAppConfig.GetBaseUrl();
        this.allocationPercentageError = "";
    }

    EmployeeDownChange(id: any) {
        this.httpClient.get(this.baseUrl + this.apiController + "/GetAllocation/" + id
        ).subscribe(
            m => {
                this.pageObject.ExistingAllocation = (m == null) ? 0 : m;
                this.pageObject.PercentageAllocation = 0;
            });
    }

    GetProjectRole(projectId: any) {
        this.httpClient.get(this.baseUrl + this.apiController + "/GetProjectRole/" + projectId
        ).subscribe(
            m => {
                if (m['length'] == 0) {
                    this.ProjectRoleMessage = true;
                    this.pageObject.SelectListMasterRole = [];
                }
                else {
                    this.ProjectRoleMessage = false;
                    this.pageObject.SelectListMasterRole = m;
                }
            });
    }

    ValidateAllocation() {
        var CurrentAllocation = this.pageObject.PercentageAllocation;
        var ExistingAllocation = this.pageObject.ExistingAllocation ;
        var RemainingAllocation = 100 - ExistingAllocation;
        var TotalValidation = ExistingAllocation + CurrentAllocation;
        if (ExistingAllocation > 0) {
            if (CurrentAllocation > RemainingAllocation) {
                this.allocationPercentageError = "User already allotted " + ExistingAllocation + "%. Can only utilize " + RemainingAllocation + "%";
                this.validForm = true;
            }
            else {
                this.allocationPercentageError = "";
                this.validForm = false;
            }
        }
        else {
            if (TotalValidation > 100) {
                this.allocationPercentageError = "Allocation should not be more than 100%";
                this.validForm = true;
            }
            else {
                this.allocationPercentageError = "";
                this.validForm = false;
            }
        }
    }

}


