import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AppconfigService } from './appconfig.service'
import { BootstrapModel } from '../model/bootstrapmodel'
import { ComponentSubscriptionService } from './componentsubscription.service'
import { AuthService } from "angular4-social-login";

@Injectable()
export class AuthGuardService implements CanActivate {

    constructor(private router: Router, private srvAppConfig: AppconfigService,
        private compSubSrv: ComponentSubscriptionService, public authService: AuthService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

        if (route.data != undefined && route.data != null)
        {
            if ('RightId' in route.data)
            {
                var rightId = route.data.RightId
                var right = this.srvAppConfig.GetRights(rightId);
                if (right.Read == false)
                {
                    if (rightId == 400)
                    {
                        this.authService.signOut();
                        this.srvAppConfig.ClearToken();
                        this.router.navigate(["/login"]);
                        alert("Basic right denied ( My Profile ) please contact admin.");
                    }
                    if (rightId == 404) {
                        this.router.navigate(["/myprofile"]);
                    }
                }
            }
        }

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
