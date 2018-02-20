import { NgModule } from '@angular/core';
import { Routes,
     RouterModule } from '@angular/router';

import { SkillComponent } from './skill.component';

const routes: Routes = [
  {
    path: '',
        component: SkillComponent,
    data: {
        title: 'Skill'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SkillRoutingModule {}
