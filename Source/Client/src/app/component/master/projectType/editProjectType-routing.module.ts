import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EditProjectTypeComponent } from './editProjectType.component';

const routes: Routes = [
  {
    path: '',
        component: EditProjectTypeComponent,
    data: {
        title: 'Edit Project Type'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EditProjectTypeRoutingModule {}
