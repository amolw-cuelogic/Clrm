import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProjectRoleComponent } from './projectRole.component';

const routes: Routes = [
  {
    path: '',
        component: ProjectRoleComponent,
    data: {
        title: 'Project Role'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProjectRoleRoutingModule {}
