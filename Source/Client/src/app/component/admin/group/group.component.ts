import { Component } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { AppconfigService } from '../../../service/appconfig.service'
import { Http, RequestOptions, URLSearchParams } from '@angular/http';
import * as $ from 'jquery'

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

    InitControls() {
        this.Show = this.ShowOptions[0];
        this.FilterText = "";
        this.Page = 0;
    }

    NextPage() {
        this.Page = this.Page + 1;
        this.GetGroupList();
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

    ClearFilter()
    {
        this.InitControls();
        this.GetGroupList();
    }

    ShowDropDownChange(num) {
        this.GetGroupList();
    }

    NewRecord() {

    }

    EditRecord(id: any) {

    }

    ViewRecord(id: any) {

    }

    DeleteRecord(id: any) {

    }

    //Common Search Module - END

    constructor(private httpClient: HttpClient, private SrvAppConfig: AppconfigService) {

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
        this.httpClient.get(this.baseUrl + "api/MasterGroup" + SearchParam
        ).subscribe(
            m => {
                this.GroupList = m;
                var topTableOffSet = $('.SearchPannelTable').offset().top;
                var topFooterOffSet = $('.app-footer').offset().top;
                var ht =  (topFooterOffSet - topTableOffSet) -5;
                $('.SearchPannelTable').css({ "height": ht + "px" });
                
            }
        );
    }
}


