import { Component } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { AppconfigService } from '../../../service/appconfig.service'
import { Http, RequestOptions, URLSearchParams } from '@angular/http';
import * as $ from 'jquery'
import { ActivatedRoute } from '@angular/router'
import { FormMode } from '../../../model/FormMode';
import { BootstrapModel } from '../../../model/bootstrapmodel'
import { ComponentSubscriptionService } from '../../../service/componentsubscription.service'

@Component({
    templateUrl: 'editgroup.component.html'
})
export class EditGroupComponent {

    id: number;
    mode: string;
    baseUrl: string;
    IdentityGroup: any = new Object();
    loaded: boolean = false;



    ngOnInit() {
        this.actroute.params.subscribe(params => {
            this.id = +params['id'];
            this.mode = params['mode'];
            console.log(this.mode);
            this.LoadGroup(this.id);

        });
    }

    SaveGroup() {
        var da = JSON.stringify(this.IdentityGroup);
        let headers = new HttpHeaders().set('Content-Type', 'application/json');

        this.httpClient.post(this.baseUrl + "api/MasterGroup", da, { headers: headers }).subscribe(
            m => {
                if (this.mode == this.formMode.Edit) {
                    this.LoadGroup(this.id);
                    var model = new BootstrapModel();
                    model.Title = "Saved";
                    model.MessageType = model.ModelType.Success;
                    model.Message = "Saved Successfully";
                    this.compSubSrv.OpenBootstrapModal(model);
                }
            }
        );
    }


    LoadGroup(id: any) {
        this.httpClient.get(this.baseUrl + "api/MasterGroup/" + id
        ).subscribe(
            m => {
                this.IdentityGroup = m;

                this.SrvAppConfig.AdjustBottomHeight();

            }
            );
    }


    constructor(private httpClient: HttpClient, private SrvAppConfig: AppconfigService,
        private actroute: ActivatedRoute, private formMode: FormMode, private compSubSrv: ComponentSubscriptionService) {
        this.baseUrl = this.SrvAppConfig.GetBaseUrl();
    }

}


