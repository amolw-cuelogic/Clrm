import { Injectable } from '@angular/core';
import { isDevMode } from '@angular/core';

//Model
import { User } from '../model/user';

@Injectable()
export class AppconfigService {

    private baseUrlDev: any = "http://localhost/Cuelogic.Clrm.Api/";
    private baseUrlProd: any = "http://localhost/Cuelogic.Clrm.Api/";
    private user: User = new User();

    constructor() { }

    GetBaseUrl() {
        if (isDevMode())
            return this.baseUrlDev;
        else
            return this.baseUrlProd;
    }

    GetRights(RightId: number) {
        var rightObject = null;
        var rightJsonString = localStorage.getItem("Rights");
        if (rightJsonString != undefined && rightJsonString != null && rightJsonString != "") {
            var rightsList = JSON.parse(rightJsonString);
            for (var i = 0; i < rightsList.length; i++) {
                if (rightsList[i].RightId == RightId) {
                    rightObject = rightsList[i].BooleanRight;
                    break;
                }
            }

        }
        return rightObject;
    }

    SetToken(user: User) {
        this.user = user;
        localStorage.setItem("AccessToken", this.user.AccessToken);
        localStorage.setItem("DisplayName", this.user.DisplayName);
        localStorage.setItem("Email", this.user.Email);
        localStorage.setItem("PhotoUrl", this.user.PhotoUrl);
        localStorage.setItem("Rights", this.user.Rights);
    }

    GetToken() {
        var token = localStorage.getItem("AccessToken");
        if (token != null && token != undefined && token != "") {
            this.user.AccessToken = token;
            this.user.DisplayName = localStorage.getItem("DisplayName");
            this.user.Email = localStorage.getItem("Email");
            this.user.PhotoUrl = localStorage.getItem("PhotoUrl");
            this.user.Rights = localStorage.getItem("Rights");
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

    AdjustBottomHeight() {
        var topTableOffSet = $('.dynamicBottomDiv').offset().top;
        var winHt = $(window).height();
        var footerHeight = 50;
        var topFooterOffSet = winHt - footerHeight;
        var ht = (topFooterOffSet - topTableOffSet) - 5;
        $('.dynamicBottomDiv').css({ "height": ht + "px" });
    }

}
