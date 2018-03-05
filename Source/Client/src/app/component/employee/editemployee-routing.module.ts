import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EditEmployeeComponent } from './editemployee.component';

const routes: Routes = [
  {
    path: '',
        component: EditEmployeeComponent,
    data: {
        title: 'Edit Employee'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EditEmployeeRoutingModule {}
