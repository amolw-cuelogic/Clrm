import { Component, OnInit } from '@angular/core';
import { AuthService } from '../service/auth.service';
import { AngularFireAuth, AngularFireAuthProvider, AngularFireAuthModule } from 'angularfire2/auth';

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
    providers: [AppconfigService, AngularFireAuth, AuthService]
})
export class FullLayoutComponent implements OnInit {

    public disabled = false;
    public status: { isopen: boolean } = { isopen: false };

    user: User = this.srvAppconfig.GetToken();

    constructor(private srvAppconfig: AppconfigService, private httpClient: HttpClient,
        private router: Router, private srvAuth: AuthService) {

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
        this.httpClient.post(baseUrl + "api/Account/Logout", null).subscribe(
            m => {
                this.srvAuth.logoutFromGoogle();
                this.srvAppconfig.ClearToken();
                this.router.navigate(['/login']);
            }
        );
    }

    ngOnInit(): void {

    }
}
