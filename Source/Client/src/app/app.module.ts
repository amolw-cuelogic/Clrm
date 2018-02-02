import { NgModule, ErrorHandler  } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { LocationStrategy, HashLocationStrategy } from '@angular/common';

import { AppComponent } from './app.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { NAV_DROPDOWN_DIRECTIVES } from './shared/nav-dropdown.directive';

import { ChartsModule } from 'ng2-charts/ng2-charts';
import { SIDEBAR_TOGGLE_DIRECTIVES } from './shared/sidebar.directive';
import { AsideToggleDirective } from './shared/aside.directive';
import { BreadcrumbsComponent } from './shared/breadcrumb.component';

//HTTP Module
import { HttpModule } from '@angular/http';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

// Routing Module
import { AppRoutingModule } from './app.routing';

// Layouts
import { FullLayoutComponent } from './layouts/full-layout.component';

//Component
import { LoginComponent } from './component/login/login.component';
import { BootstrapmodalComponent } from './shared/bootstrapmodal.component';

//Service
import { AppconfigService } from './service/appconfig.service';
import { InterceptorService } from './service/interceptor.service';
import { AuthGuard } from './service/authguard.service';
import { ErrorhandlerService } from './service/errorhandler.service'
import { BootstrapmodalService } from './service/bootstrapmodal.service'

//Social login
import { SocialLoginModule, AuthServiceConfig } from "angular4-social-login";
import { GoogleLoginProvider } from "angular4-social-login";


let config = new AuthServiceConfig([
    {
        id: GoogleLoginProvider.PROVIDER_ID,
        provider: new GoogleLoginProvider("15147801980-uhliicuk0kpn72ukm45oobidk14afguc.apps.googleusercontent.com")
    }
]);

export function provideConfig() {
    return config;
}

@NgModule({
    imports: [
        BrowserModule,
        AppRoutingModule,
        BsDropdownModule.forRoot(),
        TabsModule.forRoot(),
        ChartsModule,
        HttpModule,
        HttpClientModule,
        SocialLoginModule
    ],
    declarations: [
        AppComponent,
        FullLayoutComponent,
        NAV_DROPDOWN_DIRECTIVES,
        BreadcrumbsComponent,
        SIDEBAR_TOGGLE_DIRECTIVES,
        AsideToggleDirective,
        LoginComponent,
        BootstrapmodalComponent
    ],
    providers: [
        AuthGuard,
        AppconfigService,
        BootstrapmodalService,
        {
            provide: AuthServiceConfig,
            useFactory: provideConfig
        },
        {
            provide: HTTP_INTERCEPTORS,
            useClass: InterceptorService,
            multi: true
        },
        {
            provide: ErrorHandler,
            useClass: ErrorhandlerService
        }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
