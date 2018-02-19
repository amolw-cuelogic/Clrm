import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EditSkillComponent } from './editskill.component';

const routes: Routes = [
  {
    path: '',
        component: EditSkillComponent,
    data: {
        title: 'Edit Skill'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EditSkillRoutingModule {}
