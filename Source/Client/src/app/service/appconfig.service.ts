import { Injectable } from '@angular/core';
import { isDevMode } from '@angular/core';

//Model
import { User } from '../model/user';

@Injectable()
export class AppconfigService {

    private baseUrlDev: any = "http://localhost:57712/";
    private baseUrlProd: any = "";
    private user: User = new User();

    constructor() { }

    GetBaseUrl() {
        if (isDevMode())
            return this.baseUrlDev;
        else
            return this.baseUrlProd;
    }

    SetToken(user: User) {
        this.user = user;
        localStorage.setItem("AccessToken", this.user.AccessToken);
        localStorage.setItem("DisplayName", this.user.DisplayName);
        localStorage.setItem("Email", this.user.Email);
        localStorage.setItem("PhotoUrl", this.user.PhotoUrl);
    }

    GetToken() {
        var token = localStorage.getItem("AccessToken");
        if (token != null && token != undefined && token != "") {
            this.user.AccessToken = token;
            this.user.DisplayName = localStorage.getItem("DisplayName");
            this.user.Email = localStorage.getItem("Email")
            this.user.PhotoUrl = localStorage.getItem("PhotoUrl")
            return this.user;
        }
        else
            return new User();
    }

    ClearToken() {
        localStorage.setItem("AccessToken", "");
        localStorage.setItem("DisplayName", "");
        localStorage.setItem("Email", "");
        localStorage.setItem("PhotoUrl", "");
    }

    GetGmailLogoutUrl() {
        var ClientBaseUrl = window.location.origin;
        var url = "https://www.google.com/accounts/Logout?continue=https://appengine.google.com/_ah/logout?continue=" + ClientBaseUrl;
        return url;
    }

}
