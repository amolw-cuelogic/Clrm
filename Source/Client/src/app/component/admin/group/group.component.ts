import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppconfigService } from '../../../service/appconfig.service'

@Component({
    templateUrl: 'group.component.html'
})
export class GroupComponent {

    baseUrl: string;
    GroupList: any;

    constructor(private httpClient: HttpClient, private SrvAppConfig: AppconfigService) {
        this.baseUrl = this.SrvAppConfig.GetBaseUrl();
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

    GetGroupList() {
        this.httpClient.get(this.baseUrl +"api/MasterGroup").subscribe(
            m => {
                this.GroupList = m;
            }
        );
    }
}


