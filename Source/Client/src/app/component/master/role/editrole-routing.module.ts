import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EditRoleComponent } from './editrole.component';

const routes: Routes = [
  {
    path: '',
        component: EditRoleComponent,
    data: {
        title: 'Edit Role'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EditRoleRoutingModule {}
