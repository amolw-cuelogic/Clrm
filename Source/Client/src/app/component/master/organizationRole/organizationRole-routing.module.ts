import { NgModule } from '@angular/core';
import { Routes,
     RouterModule } from '@angular/router';

import { OrganizationRoleComponent } from './organizationRole.component';

const routes: Routes = [
  {
    path: '',
        component: OrganizationRoleComponent,
    data: {
        title: 'Organization Role'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrganizationRoleRoutingModule {}
