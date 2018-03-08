import { Injectable } from '@angular/core';
import { isDevMode } from '@angular/core';

//Model
import { User } from '../model/user';

@Injectable()
export class AppconfigService {

    private baseUrlDev: any = "http://localhost/Cuelogic.Clrm.Api/";
    private baseUrlProd: any = "http://amolw-pc/clrmapi/";
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
        var user = this.GetToken();

        if (user.Rights != undefined && user.Rights != null && user.Rights != "") {
            var rightsList = JSON.parse(user.Rights);
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
        var data = JSON.stringify(user);
        var encryptData = btoa(data);
        localStorage.setItem("accessToken", encryptData);
    }

    GetToken() {
        var data = localStorage.getItem("accessToken");

        if (data != null && data != undefined && data != "") {
            var decryptData = atob(data)
            this.user = JSON.parse(decryptData);
            return this.user;
        }
        else
            return new User();
    }

    ClearToken() {
        localStorage.removeItem("accessToken");
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
