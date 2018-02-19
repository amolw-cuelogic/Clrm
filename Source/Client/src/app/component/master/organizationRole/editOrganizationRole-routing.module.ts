import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EditOrganizationRoleComponent } from './editOrganizationRole.component';

const routes: Routes = [
  {
    path: '',
        component: EditOrganizationRoleComponent,
    data: {
        title: 'Edit Organization Role'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EditOrganizationRoleRoutingModule {}
