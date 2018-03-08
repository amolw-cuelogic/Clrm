import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UserGroupComponent } from './usergroup.component';

const routes: Routes = [
  {
    path: '',
        component: UserGroupComponent,
    data: {
        title: 'User Group'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserGroupRoutingModule {}
