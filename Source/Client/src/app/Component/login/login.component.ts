import { Component, OnInit } from '@angular/core';

//Services
import { AuthService } from '../../service/auth.service';
import { AppconfigService } from '../../service/appconfig.service';

//Model
import { User } from '../../model/user';

//Firebase
import { AngularFireAuth, AngularFireAuthProvider, AngularFireAuthModule } from 'angularfire2/auth';

//HTTP 
import { Http } from '@angular/http';
import { Headers, RequestOptions } from '@angular/http';
import { Router } from '@angular/router'

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss'],
    providers: [AngularFireAuth, AuthService, User]
})
export class LoginComponent implements OnInit {

    photoUrl: any;
    constructor(public authService: AuthService, private srvAppConfig: AppconfigService,
        private httpClient: Http, private user: User,
        private router: Router) {

    }
    

    login() {
        this.authService.loginWithGoogle().then((data) => {
            console.log(data);
            debugger;
            this.RegisterGmailToken(data);
        })
    }

    private RegisterGmailToken(authData) {
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        let options = new RequestOptions({ headers: headers });
        var data = "grant_type=password&username=" + authData.user.email + "&password=password";
        var baseurl = this.srvAppConfig.GetBaseUrl();
        this.httpClient.post(baseurl + 'token', data, { headers: headers }).subscribe(
            m => {

                var credentials = JSON.parse(m["_body"]);
                console.log(credentials);
                this.user.AccessToken = credentials.access_token;
                this.user.DisplayName = authData.user.displayName;
                this.user.Email = authData.user.email;
                this.user.PhotoUrl = authData.user.photoURL;
                this.srvAppConfig.SetToken(this.user);
                window.location.href = '/';

            }
        );
    }

    ngOnInit() {
        var token = this.srvAppConfig.GetToken();
        if (token != null && token != undefined)
        {
            if (token.AccessToken != "" && token.AccessToken != undefined && token.AccessToken != null)
                window.location.href = '/';
        }
    }

}
