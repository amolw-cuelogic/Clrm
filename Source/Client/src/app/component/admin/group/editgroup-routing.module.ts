import { NgModule } from '@angular/core';
import { Routes,
     RouterModule } from '@angular/router';

import { EditGroupComponent } from './editgroup.component';

const routes: Routes = [
  {
    path: '',
        component: EditGroupComponent,
    data: {
        title: 'Edit Group'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EditGroupRoutingModule {}
