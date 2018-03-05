import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProjectTypeComponent } from './projectType.component';

const routes: Routes = [
  {
    path: '',
        component: ProjectTypeComponent,
    data: {
        title: 'Project Type'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProjectTypeRoutingModule {}
