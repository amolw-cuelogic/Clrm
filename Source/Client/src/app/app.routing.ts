import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './component/login/login.component'

// Layouts
import { FullLayoutComponent } from './layouts/full-layout.component';

//Service
import { AuthGuard } from './service/authguard.service';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full',
        canActivate: [AuthGuard]
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
                canActivate: [AuthGuard]
            },
            {
                path: 'group',
                loadChildren: './component/admin/group/group.module#GroupModule',
                canActivate: [AuthGuard]
            },
            {
                path: 'usergroup',
                loadChildren: './component/admin/usergroup/usergroup.module#UserGroupModule',
                canActivate: [AuthGuard]
            }
        ]
    },
    {
        path: '**',
        redirectTo: 'dashboard',
        pathMatch: 'full',
        canActivate: [AuthGuard]
    },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
