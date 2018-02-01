import { Component, OnInit } from '@angular/core';

//angular social login
import { AuthService } from "angular4-social-login";
import { FacebookLoginProvider, GoogleLoginProvider } from "angular4-social-login";
import { SocialUser } from "angular4-social-login";

//Model
import { User } from '../model/user'

//Service
import { AppconfigService } from '../service/appconfig.service'

//Router
import { Router } from '@angular/router';

//HTTP 
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Component({
    selector: 'app-dashboard',
    templateUrl: './full-layout.component.html',
    providers: [AppconfigService]
})
export class FullLayoutComponent implements OnInit {

    public disabled = false;
    public status: { isopen: boolean } = { isopen: false };

    user: User = this.srvAppconfig.GetToken();

    constructor(private srvAppconfig: AppconfigService, private httpClient: HttpClient,
        private router: Router, public authService: AuthService) {

    }

    public toggled(open: boolean): void {
        console.log('Dropdown is now: ', open);
    }

    public toggleDropdown($event: MouseEvent): void {
        $event.preventDefault();
        $event.stopPropagation();
        this.status.isopen = !this.status.isopen;
    }

    Logout() {
        var baseUrl = this.srvAppconfig.GetBaseUrl();
        var ClientBaseUrl = window.location.origin;
        this.httpClient.post(baseUrl + "api/Account/Logout", null).subscribe(
            m => {
                this.authService.signOut();
                this.srvAppconfig.ClearToken();
                location.href = "https://www.google.com/accounts/Logout?continue=https://appengine.google.com/_ah/logout?continue=" + ClientBaseUrl;
                //this.router.navigate(['/login']);
            }
        );
    }

    ngOnInit(): void {

    }
}
