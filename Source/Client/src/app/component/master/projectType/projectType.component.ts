import { Component } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { AppconfigService } from '../../../service/appconfig.service'
import * as $ from 'jquery'
import { Router } from '@angular/router'
import { FormMode } from '../../../model/FormMode';

@Component({
    templateUrl: 'projectType.component.html'
})
export class ProjectTypeComponent{

    baseUrl: string;
    PageList: any;

    //Common Search Module
    Show: number;
    ShowOptions: any = [10, 50, 100];
    FilterText: string;
    Page: number = 0;
    ApiController: string = "api/ProjectCategory/";

    InitControls() {
        this.Show = this.ShowOptions[0];
        this.FilterText = "";
        this.Page = 0;
    }

    NextPage() {
        if (this.PageList.length == this.Show) {
            this.Page = this.Page + 1;
            this.GetList();
        }
    }

    PreviousPage() {
        if (this.Page > 0) {
            this.Page = this.Page - 1;
            this.GetList();
        }
    }

    SearchFilter() {
        this.GetList();
    }

    ClearFilter() {
        this.InitControls();
        this.GetList();
    }

    ShowDropDownChange(num) {
        this.GetList();
    }

    NewRecord() {
        this.router.navigate(['/projecttype/' + this.formMode.Add + '/0']);
    }

    EditRecord(id: any) {
        this.router.navigate(['/projecttype/' + this.formMode.Edit + '/' + id]);
    }

    ViewRecord(id: any) {
        this.router.navigate(['/projecttype/' + this.formMode.View + '/' + id]);
    }

    DeleteRecord(id: any) {
        this.httpClient.delete(this.baseUrl + this.ApiController + id
        ).subscribe(
            m => {
                this.GetList();

            });
    }

    //Common Search Module - END

    constructor(private httpClient: HttpClient, private SrvAppConfig: AppconfigService,
        private router: Router, private formMode: FormMode) {

        this.InitControls();
        this.baseUrl = this.SrvAppConfig.GetBaseUrl();
        this.GetList();

    }

    GetList() {
        let params = new HttpParams();
        params.set('Show', this.Show.toString());
        params.set('FilterText', this.FilterText);
        params.set('Page', this.Page.toString());

        var SearchParam = "?Show=" + this.Show + "&FilterText=" + this.FilterText + "&Page=" + this.Page;
        this.httpClient.get(this.baseUrl + this.ApiController + SearchParam
        ).subscribe(
            m => {
                this.PageList = m;
                this.SrvAppConfig.AdjustBottomHeight();
            });
    }
}


