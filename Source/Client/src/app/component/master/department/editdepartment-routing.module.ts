import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EditDepartmentComponent } from './editdepartment.component';

const routes: Routes = [
  {
    path: '',
        component: EditDepartmentComponent,
    data: {
        title: 'Edit Department'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EditDepartmentRoutingModule {}
