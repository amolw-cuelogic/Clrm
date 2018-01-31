import { NgModule } from '@angular/core';
import { Routes,
     RouterModule } from '@angular/router';

import { NewfolderComponent } from './newfolder.component';

const routes: Routes = [
  {
    path: '',
        component: NewfolderComponent,
    data: {
      title: 'Masters'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NewfolderRoutingModule {}
