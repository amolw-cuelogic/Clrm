import { Component } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { AppconfigService } from '../../../service/appconfig.service'
import { Http, RequestOptions, URLSearchParams } from '@angular/http';
import * as $ from 'jquery'
import { ActivatedRoute } from '@angular/router'

@Component({
    templateUrl: 'editgroup.component.html'
})
export class EditGroupComponent {

    id: number;
    baseUrl: string;
    IdentityGroup: any = new Object();
    loaded: boolean = false;

    ngOnInit() {
        this.actroute.params.subscribe(params => {
            this.id = +params['id'];

            this.LoadGroup(this.id);

        });
    }

    SaveGroup() {
        var da = JSON.stringify(this.IdentityGroup);
        let headers = new HttpHeaders().set('Content-Type', 'application/json');

        this.httpClient.post(this.baseUrl + "api/MasterGroup", da, { headers: headers }).subscribe(
            m => {
                
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
        private actroute: ActivatedRoute) {
        this.baseUrl = this.SrvAppConfig.GetBaseUrl();
    }

}


