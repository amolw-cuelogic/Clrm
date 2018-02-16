import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './component/login/login.component'

// Layouts
import { FullLayoutComponent } from './layouts/full-layout.component';

//Service
import { AuthGuardService } from './service/authguard.service';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full',
        canActivate: [AuthGuardService]
    },
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: '',
        component: FullLayoutComponent,
        data: {
            title: 'Home'
        },
        children: [
            {
                path: 'dashboard',
                loadChildren: './Component/dashboard/dashboard.module#DashboardModule',
                canActivate: [AuthGuardService]
            }
        ]
    },
    {
        path: '',
        component: FullLayoutComponent,
        data: {
            title: 'Admin'
        },
        children: [
            {
                path: 'group',
                loadChildren: './component/admin/group/group.module#GroupModule',
                canActivate: [AuthGuardService]
            },
            {
                path: 'group/:mode/:id',
                loadChildren: './component/admin/group/editgroup.module#EditGroupModule',
                canActivate: [AuthGuardService]
            },
            {
                path: 'usergroup',
                loadChildren: './component/admin/usergroup/usergroup.module#UserGroupModule',
                canActivate: [AuthGuardService]
            }
            
        ]
    },
    {
        path: '**',
        redirectTo: 'dashboard',
        pathMatch: 'full',
        canActivate: [AuthGuardService]
    },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
