import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EditClientComponent } from './editclient.component';

const routes: Routes = [
  {
    path: '',
        component: EditClientComponent,
    data: {
        title: 'Edit Client'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EditClientRoutingModule {}
