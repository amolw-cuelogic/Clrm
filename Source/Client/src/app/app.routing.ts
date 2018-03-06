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
                canActivate: [AuthGuardService],
                data: { RightId: 404 }
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
                path: 'projectrole',
                loadChildren: './component/master/projectRole/projectRole.module#ProjectRoleModule',
                canActivate: [AuthGuardService]
            },
            {
                path: 'projectrole/:mode/:id',
                loadChildren: './component/master/projectRole/editProjectRole.module#EditProjectRoleModule',
                canActivate: [AuthGuardService]
            },
            {
                path: 'projecttype',
                loadChildren: './component/master/projectType/projectType.module#ProjectTypeModule',
                canActivate: [AuthGuardService]
            },
            {
                path: 'projecttype/:mode/:id',
                loadChildren: './component/master/projectType/editProjectType.module#EditProjectTypeModule',
                canActivate: [AuthGuardService]
            },
            {
                path: 'client',
                loadChildren: './component/master/client/client.module#ClientModule',
                canActivate: [AuthGuardService]
            },
            {
                path: 'client/:mode/:id',
                loadChildren: './component/master/client/editclient.module#EditClientModule',
                canActivate: [AuthGuardService]
            }
        ]
    },
    {
        path: '',
        component: FullLayoutComponent,
        data: {
            title: 'Home'
        },
        children: [
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
        path: '',
        component: FullLayoutComponent,
        data: {
            title: 'Home'
        },
        children: [
            {
                path: 'allocation',
                loadChildren: './component/allocation/allocation.module#AllocationModule',
                canActivate: [AuthGuardService]
            },
            {
                path: 'allocation/:mode/:id',
                loadChildren: './component/allocation/editallocation.module#EditAllocationModule',
                canActivate: [AuthGuardService]
            }
        ]
    },
    {
        path: '',
        component: FullLayoutComponent,
        data: {
            title: 'Home'
        },
        children: [
            {
                path: 'project',
                loadChildren: './component/project/project.module#ProjectModule',
                canActivate: [AuthGuardService]
            },
            {
                path: 'project/:mode/:id',
                loadChildren: './component/project/editproject.module#EditProjectModule',
                canActivate: [AuthGuardService]
            }
        ]
    },
    {
        path: '',
        component: FullLayoutComponent,
        data: {
            title: 'Home'
        },
        children: [
            {
                path: 'myprofile',
                loadChildren: './component/myprofile/editmyprofile.module#EditMyProfileModule',
                canActivate: [AuthGuardService],
                data: { RightId: 400 }
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
