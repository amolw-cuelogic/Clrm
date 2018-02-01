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
import { AngularFireModule } from 'angularfire2';

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
import { AuthService } from './service/auth.service';
import { AppconfigService } from './service/appconfig.service';
import { InterceptorService } from './service/interceptor.service';

export const firebaseConfig = {
    apiKey: "AIzaSyDMQ55IMy9XFdhggn0w9ru4x5ECXcnY9qo",
    authDomain: "cuelogicresourcemanagement.firebaseapp.com",
    databaseURL: "https://cuelogicresourcemanagement.firebaseio.com",
    projectId: "cuelogicresourcemanagement",
    storageBucket: "cuelogicresourcemanagement.appspot.com",
    messagingSenderId: "563336911403"
};

@NgModule({
    imports: [
        BrowserModule,
        AppRoutingModule,
        BsDropdownModule.forRoot(),
        TabsModule.forRoot(),
        ChartsModule,
        AngularFireModule.initializeApp(firebaseConfig),
        HttpModule,
        HttpClientModule
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
    providers: [AuthService,
        AppconfigService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: InterceptorService,
            multi: true
        }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
