import { NgModule } from '@angular/core';
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

//Service
import { AppconfigService } from './service/appconfig.service';
import { InterceptorService } from './service/interceptor.service';
import { AuthGuard } from './service/authguard.service';

import { SocialLoginModule, AuthServiceConfig } from "angular4-social-login";
import { GoogleLoginProvider, FacebookLoginProvider } from "angular4-social-login";

let config = new AuthServiceConfig([
    {
        id: GoogleLoginProvider.PROVIDER_ID,
        provider: new GoogleLoginProvider("15147801980-uhliicuk0kpn72ukm45oobidk14afguc.apps.googleusercontent.com")
    },
    {
        id: FacebookLoginProvider.PROVIDER_ID,
        provider: new FacebookLoginProvider("Facebook-App-Id")
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
        LoginComponent
    ],
    providers: [
        AuthGuard,
        AppconfigService,
        {
            provide: AuthServiceConfig,
            useFactory: provideConfig
        },
        {
            provide: HTTP_INTERCEPTORS,
            useClass: InterceptorService,
            multi: true
        }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
