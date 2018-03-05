import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EditProjectRoleComponent } from './editProjectRole.component';

const routes: Routes = [
  {
    path: '',
        component: EditProjectRoleComponent,
    data: {
        title: 'Edit Project Role'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EditProjectRoleRoutingModule {}
