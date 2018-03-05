import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EditAllocationComponent } from './editallocation.component';

const routes: Routes = [
  {
    path: '',
        component: EditAllocationComponent,
    data: {
        title: 'Edit Allocation'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EditAllocationRoutingModule {}
