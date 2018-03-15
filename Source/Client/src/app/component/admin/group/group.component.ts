import { Component } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { AppconfigService } from '../../../service/appconfig.service'
import * as $ from 'jquery'
import { Router } from '@angular/router'
import { FormMode } from '../../../model/FormMode';

@Component({
    templateUrl: 'group.component.html'
})
export class GroupComponent {

    baseUrl: string;
    GroupList: any;

    //Common Search Module
    Show: number;
    ShowOptions: any = [10, 50, 100];
    FilterText: string;
    Page: number = 0;
    ApiController: string = "api/Group/";

    InitControls() {
        this.Show = this.ShowOptions[0];
        this.FilterText = "";
        this.Page = 0;
    }

    EnterkeyPress(event: any) {
        this.SearchFilter();
    }

    NextPage() {
        if (this.GroupList.length == this.Show) {
            this.Page = this.Page + 1;
            this.GetGroupList();
        }
    }

    PreviousPage() {
        if (this.Page > 0) {
            this.Page = this.Page - 1;
            this.GetGroupList();
        }
    }

    SearchFilter() {
        this.GetGroupList();
    }

    ClearFilter() {
        this.InitControls();
        this.GetGroupList();
    }

    ShowDropDownChange(num) {
        this.GetGroupList();
    }

    NewRecord() {
        this.router.navigate(['/group/' + this.formMode.Add + '/0']);
    }

    EditRecord(id: any) {
        this.router.navigate(['/group/' + this.formMode.Edit + '/' + id]);
    }

    ViewRecord(id: any) {
        this.router.navigate(['/group/' + this.formMode.View + '/' + id]);
    }

    DeleteRecord(id: any) {
        this.httpClient.delete(this.baseUrl + this.ApiController + id
        ).subscribe(
            m => {
                this.GetGroupList();

            });
    }

    //Common Search Module - END

    constructor(private httpClient: HttpClient, private SrvAppConfig: AppconfigService,
        private router: Router, private formMode: FormMode) {

        this.InitControls();
        this.baseUrl = this.SrvAppConfig.GetBaseUrl();
        this.GetGroupList();

    }



    GetGroupList() {

        let params = new HttpParams();
        params.set('Show', this.Show.toString());
        params.set('FilterText', this.FilterText);
        params.set('Page', this.Page.toString());

        var SearchParam = "?Show=" + this.Show + "&FilterText=" + this.FilterText + "&Page=" + this.Page;
        this.httpClient.get(this.baseUrl + this.ApiController + SearchParam
        ).subscribe(
            m => {
                this.GroupList = m;
                this.SrvAppConfig.AdjustBottomHeight();

            }
            );
    }
}


