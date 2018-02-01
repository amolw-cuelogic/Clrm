import { Component, OnInit } from '@angular/core';

//angular social login
import { AuthService } from "angular4-social-login";
import { FacebookLoginProvider, GoogleLoginProvider } from "angular4-social-login";
import { SocialUser } from "angular4-social-login";

//Service
import { AppconfigService } from '../../service/appconfig.service';

//Model
import { User } from '../../model/user';

//HTTP 
import { Http } from '@angular/http';
import { Headers, RequestOptions } from '@angular/http';
import { Router } from '@angular/router'

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss'],
    providers: [User]
})
export class LoginComponent implements OnInit {


    constructor(public authService: AuthService, private srvAppConfig: AppconfigService,
        private httpClient: Http, private user: User,
        private router: Router) {

    }

    login() {
        
        this.authService.signIn(GoogleLoginProvider.PROVIDER_ID).then(
            m => {
                this.RegisterGmailToken(m);
            }
        );
    }

    RegisterGmailToken(authData) {

        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        let options = new RequestOptions({ headers: headers });
        var data = "grant_type=password&username=" + authData.email + "&password=password";
        var baseurl = this.srvAppConfig.GetBaseUrl();
        this.httpClient.post(baseurl + 'token', data, { headers: headers }).subscribe(
            m => {

                var credentials = JSON.parse(m["_body"]);
                this.user.AccessToken = credentials.access_token;
                this.user.DisplayName = authData.name;
                this.user.Email = authData.email;
                this.user.PhotoUrl = authData.photoUrl;
                this.srvAppConfig.SetToken(this.user);
                window.location.href = '/';

            }
        );

    }

    ngOnInit() {
       
    }

}
