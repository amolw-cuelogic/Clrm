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
    templateUrl: 'editclient.component.html'
})
export class EditClientComponent {

    id: number;
    mode: string;
    baseUrl: string;
    pageObject: any = new Object();
    loaded: boolean = false;
    ApiController: string = "api/Client";

    Disabled = false;

    ngOnInit() {
        this.actroute.params.subscribe(params => {
            this.id = +params['id'];
            this.mode = params['mode'];
            this.LoadDepartment(this.id);
        });
    }

    SetFormModeView() {
        this.Disabled = true;
        $('.dynamicBottomDiv input,.dynamicBottomDiv textarea,input[type="checkbox"]').attr("disabled", "true");
    }

    Save() {
        var da = JSON.stringify(this.pageObject);
        let headers = new HttpHeaders().set('Content-Type', 'application/json');

        this.httpClient.post(this.baseUrl + this.ApiController, da, { headers: headers }).subscribe(
            m => {
                if (this.mode == this.formMode.Edit) {
                    this.LoadDepartment(this.id);
                    var model = new BootstrapModel();
                    model.Title = "Saved";
                    model.MessageType = model.ModelType.Success;
                    model.Message = "Saved Successfully";
                    this.compSubSrv.OpenBootstrapModal(model);
                }
                else {
                    this.router.navigate(["/client"]);
                    var model = new BootstrapModel();
                    model.Title = "Saved";
                    model.MessageType = model.ModelType.Success;
                    model.Message = "Saved Successfully";
                    this.compSubSrv.OpenBootstrapModal(model);
                }
            }
        );
    }


    LoadDepartment(id: any) {
        this.httpClient.get(this.baseUrl + this.ApiController + "/" + id
        ).subscribe(
            m => {
                if (m["CountryId"] == 0)
                    m["CountryId"] = null;
                if (m["CityId"] == 0)
                    m["CityId"] = null;
                this.pageObject = m;
                this.SrvAppConfig.AdjustBottomHeight();

                if (this.mode == this.formMode.View) {
                    this.SetFormModeView();
                }
            }
            );
    }

    GetCities(id: any) {
        this.httpClient.get(this.baseUrl + this.ApiController + "/GetCities/" + id
        ).subscribe(
            m => {
                if (m != null && m != undefined) {
                    this.pageObject.MasterCityList = m;
                    this.pageObject.CityId = null;
                    this.SrvAppConfig.AdjustBottomHeight();
                }
                else {
                    this.ThrowCityNotPresentWarning();
                }



            }
            );
    }

    ThrowCityNotPresentWarning() {
        var model = new BootstrapModel();
        model.Title = "Warning";
        model.MessageType = model.ModelType.Warning;
        model.Message = "City not entered for selected country.";
        this.compSubSrv.OpenBootstrapModal(model);
    }

    constructor(private httpClient: HttpClient, private SrvAppConfig: AppconfigService,
        private actroute: ActivatedRoute, private formMode: FormMode, private compSubSrv: ComponentSubscriptionService,
        private router: Router) {
        this.baseUrl = this.SrvAppConfig.GetBaseUrl();
    }

}


