import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EditProjectComponent } from './editproject.component';

const routes: Routes = [
  {
    path: '',
        component: EditProjectComponent,
    data: {
        title: 'Edit Project'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EditProjectRoutingModule {}
