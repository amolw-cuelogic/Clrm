import { Component, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AppconfigService } from '../../service/appconfig.service'
import * as $ from 'jquery'
import { ActivatedRoute } from '@angular/router'
import { FormMode } from '../../model/FormMode';
import { BootstrapModel } from '../../model/bootstrapmodel'
import { ComponentSubscriptionService } from '../../service/componentsubscription.service'
import { Router } from '@angular/router'

@Component({
    templateUrl: 'editemployee.component.html'
})
export class EditEmployeeComponent {
    //public departmentModal;
    //public organizationRoleModal;
    //public groupModal;
    //public skillModal;

    id: number;
    mode: string;
    baseUrl: string;
    pageObject: any = new Object({
        Employee: new Object(),
        IdentityGroupList: new Object(),
        MasterDepartmentList: new Object(),
        MasterOrganizationRoleList: new Object(),
        MasterSkillList: new Object()
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
                    this.compSubSrv.OpenBootstrapModal(model);
                }
                else {
                    this.router.navigate(["/employee"]);
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
                this.pageObject = m;
                this.serviceAppConfig.AdjustBottomHeight();

                if (this.mode == this.formMode.View) {
                    this.SetFormModeView();
                }
            }
            );
    }


    constructor(private httpClient: HttpClient, private serviceAppConfig: AppconfigService,
        private actroute: ActivatedRoute, private formMode: FormMode, private compSubSrv: ComponentSubscriptionService,
        private router: Router) {
        this.baseUrl = this.serviceAppConfig.GetBaseUrl();
    }

}


