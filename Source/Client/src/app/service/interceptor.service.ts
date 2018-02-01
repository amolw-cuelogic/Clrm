import { Injectable, Injector } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/observable/throw'
import 'rxjs/add/operator/catch';
import { Router } from '@angular/router';
import { AppconfigService } from './appconfig.service'

@Injectable()
export class InterceptorService implements HttpInterceptor {
    constructor(private router: Router, private srvAppConfig: AppconfigService) { }
    token: any;
    authReq: any;
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        //Clone the request to add the new header.

        var token = this.srvAppConfig.GetToken().AccessToken;

        this.authReq = req.clone({ headers: req.headers.set("Authorization", "Bearer " + token) });

        //send the newly created request
        return next.handle(this.authReq)
            .catch((error, caught) => {

                this.token = token;
                if (this.token == null || this.token == undefined) {
                    this.router.navigate(['/login']);
                    //return Observable.throw('Not Logged In.');

                }

                //intercept the respons error and displace it to the console

                if (error.status == 401 || error.status == 0) {
                    this.router.navigate(['/login']);
                }
                //return the error to the method that called it
                return Observable.throw(error);
            }) as any;
    }
}


