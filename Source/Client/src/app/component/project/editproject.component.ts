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
    templateUrl: 'editproject.component.html'
})
export class EditProjectComponent {

    id: number;
    mode: string;
    baseUrl: string;
    pageObject: any = new Object({
        ProjectMasterClientList: [],
        ProjectTypeList: [],
        ProjectRoleList: [],
        MasterCurrencyList: [],
        MasterRoleList: []
    });
    loaded: boolean = false;
    apiController: string = "api/Project";

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
                    this.compSubSrv.OpenBootstrapModal(model);
                }
                else {
                    this.router.navigate(["/project"]);
                    var model = new BootstrapModel();
                    model.Title = "Saved";
                    model.MessageType = model.ModelType.Success;
                    model.Message = "Saved Successfully";
                    this.compSubSrv.OpenBootstrapModal(model);
                }
            }
        );
    }


    LoadEditPage(id: any) {
        this.httpClient.get(this.baseUrl + this.apiController + "/" + id
        ).subscribe(
            m => {
                if (m["ProjectTypeId"] == 0)
                    m["ProjectTypeId"] = null;
                if (m["ClientId"] == 0)
                    m["ClientId"] = null;
                this.pageObject = m;
                this.serviceAppConfig.AdjustBottomHeight();

                if (this.mode == this.formMode.View) {
                    this.SetFormModeView();
                }
            }
            );
    }

    NewRecord() {
        var projectRoleObj = new Object({
            Id:0,
            RoleId: null,
            BillingRate: 0,
            Currency: null,
            IsValid: true
        });
        this.pageObject.ProjectRoleList.push(projectRoleObj);
    }

    RemoveRecord(index:any) {
        this.pageObject.ProjectRoleList.splice(index, 1);
    }

    constructor(private httpClient: HttpClient, private serviceAppConfig: AppconfigService,
        private actroute: ActivatedRoute, private formMode: FormMode, private compSubSrv: ComponentSubscriptionService,
        private router: Router, private commonService: CommonService) {
        this.baseUrl = this.serviceAppConfig.GetBaseUrl();

    }

}


