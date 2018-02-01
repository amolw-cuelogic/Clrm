import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AppconfigService } from './appconfig.service'

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private router: Router, private srvAppConfig: AppconfigService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

        var token = this.srvAppConfig.GetToken();

        if (token != undefined && token != null)
        {
            if (token.AccessToken != "" && token.AccessToken != null && token.AccessToken != undefined)
                return true;
            else {
                this.router.navigate(['login']);
                return false;
            }
        }
        else {
            this.router.navigate(['login']);
            return false;
        }
    }
}