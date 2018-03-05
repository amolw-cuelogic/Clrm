import { Component } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { AppconfigService } from '../../service/appconfig.service'
import * as $ from 'jquery'
import { Router } from '@angular/router'
import { FormMode } from '../../model/FormMode';

@Component({
    templateUrl: 'project.component.html'
})
export class ProjectComponent {

    baseUrl: string;
    pageList: any;

    //Common Search Module
    show: number;
    showOptions: any = [10, 50, 100];
    filterText: string;
    page: number = 0;
    apiController: string = "api/Project/";

    InitControls() {
        this.show = this.showOptions[0];
        this.filterText = "";
        this.page = 0;
    }

    NextPage() {
        if (this.pageList.length == this.show) {
            this.page = this.page + 1;
            this.GetList();
        }
    }

    PreviousPage() {
        if (this.page > 0) {
            this.page = this.page - 1;
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
        this.router.navigate(['/project/' + this.formMode.Add + '/0']);
    }

    EditRecord(id: any) {
        this.router.navigate(['/project/' + this.formMode.Edit + '/' + id]);
    }

    ViewRecord(id: any) {
        this.router.navigate(['/project/' + this.formMode.View + '/' + id]);
    }

    DeleteRecord(id: any) {
        this.httpClient.delete(this.baseUrl + this.apiController + id
        ).subscribe(
            m => {
                this.GetList();

            });
    }

    //Common Search Module - END

    constructor(private httpClient: HttpClient, private serviceAppConfig: AppconfigService,
        private router: Router, private formMode: FormMode) {

        this.InitControls();
        this.baseUrl = this.serviceAppConfig.GetBaseUrl();
        this.GetList();

    }

    GetList() {
        let params = new HttpParams();
        params.set('Show', this.show.toString());
        params.set('FilterText', this.filterText);
        params.set('Page', this.page.toString());

        var SearchParam = "?show=" + this.show + "&filterText=" + this.filterText + "&page=" + this.page;
        this.httpClient.get(this.baseUrl + this.apiController + SearchParam
        ).subscribe(
            m => {
                this.pageList = m;
                this.serviceAppConfig.AdjustBottomHeight();
            });
    }
}


