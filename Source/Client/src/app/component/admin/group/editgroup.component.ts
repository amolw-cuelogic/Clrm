import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AppconfigService } from '../../../service/appconfig.service'
import * as $ from 'jquery'
import { ActivatedRoute } from '@angular/router'
import { FormMode } from '../../../model/FormMode';
import { BootstrapModel } from '../../../model/bootstrapmodel'
import { ComponentSubscriptionService } from '../../../service/componentsubscription.service'
import { Router } from '@angular/router'

@Component({
    templateUrl: 'editgroup.component.html'
})
export class EditGroupComponent {

    id: number;
    mode: string;
    baseUrl: string;
    IdentityGroup: any = new Object();
    loaded: boolean = false;
    ApiController: string = "api/Group";

    ActionWrite: boolean;
    ActionRead: boolean;
    ActionInValid: boolean;

    Disabled = false;

    ngOnInit() {
        this.actroute.params.subscribe(params => {
            this.id = +params['id'];
            this.mode = params['mode'];
            this.LoadGroup(this.id);
            this.ActionWrite = false;
            this.ActionRead = false;
            this.ActionInValid = false;
        });
    }

    SetFormModeView() {
        this.Disabled = true;
        $('.dynamicBottomDiv input,.dynamicBottomDiv textarea,input[type="checkbox"]').attr("disabled", "true");
    }

    SaveGroup() {
        var da = JSON.stringify(this.IdentityGroup);
        let headers = new HttpHeaders().set('Content-Type', 'application/json');

        this.httpClient.post(this.baseUrl + this.ApiController, da, { headers: headers }).subscribe(
            m => {
                if (this.mode == this.formMode.Edit) {
                    this.LoadGroup(this.id);
                    var model = new BootstrapModel();
                    model.Title = "Saved";
                    model.MessageType = model.ModelType.Success;
                    model.Message = "Saved Successfully";
                    this.compSubSrv.OpenToaster(model);
                }
                else {
                    this.router.navigate(["/group"]);
                    var model = new BootstrapModel();
                    model.Title = "Saved";
                    model.MessageType = model.ModelType.Success;
                    model.Message = "Saved Successfully";
                    this.compSubSrv.OpenToaster(model);
                }
            }
        );
    }


    LoadGroup(id: any) {
        this.httpClient.get(this.baseUrl + this.ApiController + "/" + id
        ).subscribe(
            m => {
                this.IdentityGroup = m;
                this.SrvAppConfig.AdjustBottomHeight();

                if (this.mode == this.formMode.View) {
                    this.SetFormModeView();
                }
            }
            );
    }


    constructor(private httpClient: HttpClient, private SrvAppConfig: AppconfigService,
        private actroute: ActivatedRoute, private formMode: FormMode, private compSubSrv: ComponentSubscriptionService,
        private router: Router) {
        this.baseUrl = this.SrvAppConfig.GetBaseUrl();
    }

    MarkAllInvalid() {
        var val = this.ActionInValid;
        for (var i = 0; i < this.IdentityGroup.GroupRight.length; i++) {
            this.IdentityGroup.GroupRight[i].BooleanRight.Delete = val;
        }
    }

    MarkAllWrite() {
        var val = this.ActionWrite;
        for (var i = 0; i < this.IdentityGroup.GroupRight.length; i++) {
            this.IdentityGroup.GroupRight[i].BooleanRight.Write = val;
        }
    }

    MarkAllRead() {
        var val = this.ActionRead;
        for (var i = 0; i < this.IdentityGroup.GroupRight.length; i++) {
            this.IdentityGroup.GroupRight[i].BooleanRight.Read = val;
        }
    }

    ReadClick(value: boolean, index: number) {
        if (!value) {
            this.IdentityGroup.GroupRight[index].BooleanRight.Write = false;
            this.IdentityGroup.GroupRight[index].BooleanRight.Delete = false;
        }
    }

    WriteClick(value: boolean, index: number) {
        if (value) {
            this.IdentityGroup.GroupRight[index].BooleanRight.Read = true;

        }
        else {
            this.IdentityGroup.GroupRight[index].BooleanRight.Delete = false;
        }
    }

    DeleteClick(value: boolean, index: number) {
        if (value) {
            this.IdentityGroup.GroupRight[index].BooleanRight.Read = true;
            this.IdentityGroup.GroupRight[index].BooleanRight.Write = true;
        }
    }

}


