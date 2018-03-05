import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AllocationComponent } from './allocation.component';

const routes: Routes = [
  {
    path: '',
        component: AllocationComponent,
    data: {
        title: 'Allocation'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AllocationRoutingModule {}
