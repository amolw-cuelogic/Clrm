import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EditMyProfileComponent } from './editmyprofile.component';

const routes: Routes = [
  {
    path: '',
        component: EditMyProfileComponent,
    data: {
        title: 'Edit MyProfile'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EditMyProfileRoutingModule {}
