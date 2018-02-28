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
        ProjectClientChildList: [],
        ProjectMasterClientList: [],
        ProjectTypeList: []
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
        private router: Router, private commonService: CommonService) {
        this.baseUrl = this.serviceAppConfig.GetBaseUrl();

    }


    CloseModal(id: any) {
        this.commonService.HideBootstrapModal(id);
    }

    //Client Modal

    OpenModal(id: any) {
        $('#idDivModalCollection input:checkbox').closest('tr').show();
        $('#idDivModalCollection #' + id + ' input:checkbox').each(function () {
            if ($(this).is(":checked"))
                $(this).trigger('click');
        });

        for (var i = 0; i < this.pageObject.ProjectClientChildList.length; i++) {
            var item = this.pageObject.ProjectClientChildList[i];
            var ClientId = item.ClientId;
            $('#idDivModalCollection input:checkbox[data-s-id="' + ClientId + '"]').closest('tr').hide();
        }

        this.commonService.ShowBootstrapModal(id);
    }

    AddClients(id: any) {
        var indexArray = [];
        $('#idDivModalCollection #' + id + ' input:checkbox').each(function () {
            if ($(this).is(":checked")) {
                var index = $(this).attr('data-s-index');
                indexArray.push(index);
            }
        });

        for (var i = 0; i < indexArray.length; i++) {
            var masterClient = this.pageObject.ProjectMasterClientList[indexArray[i]];
            var projectClient = new Object({
                ProjectId: this.pageObject.Id,
                ClientId: masterClient.Id,
                IsValid: true,
                ClientName: masterClient.ClientName
            });
            this.pageObject.ProjectClientChildList.push(projectClient);
        }
        this.commonService.HideBootstrapModal(id);
    }

    RemoveClient(id: any) {
        this.pageObject.ProjectClientChildList.splice(id, 1);
    }
    
}


