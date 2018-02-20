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
            
        ]
    },
    {
        path: '',
        component: FullLayoutComponent,
        data: {
            title: 'Master'
        },
        children: [
            {
                path: 'department',
                loadChildren: './component/master/department/department.module#DepartmentModule',
                canActivate: [AuthGuardService]
            },
            {
                path: 'department/:mode/:id',
                loadChildren: './component/master/department/editdepartment.module#EditDepartmentModule',
                canActivate: [AuthGuardService]
            },
            {
                path: 'organizationrole',
                loadChildren: './component/master/organizationRole/organizationRole.module#OrganizationRoleModule',
                canActivate: [AuthGuardService]
            },
            {
                path: 'organizationrole/:mode/:id',
                loadChildren: './component/master/organizationRole/editOrganizationRole.module#EditOrganizationRoleModule',
                canActivate: [AuthGuardService]
            },
            {
                path: 'skill',
                loadChildren: './component/master/skill/skill.module#SkillModule',
                canActivate: [AuthGuardService]
            },
            {
                path: 'skill/:mode/:id',
                loadChildren: './component/master/skill/editskill.module#EditSkillModule',
                canActivate: [AuthGuardService]
            },
            {
                path: 'employee',
                loadChildren: './component/employee/employee.module#EmployeeModule',
                canActivate: [AuthGuardService]
            },
            {
                path: 'employee/:mode/:id',
                loadChildren: './component/employee/editemployee.module#EditEmployeeModule',
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
