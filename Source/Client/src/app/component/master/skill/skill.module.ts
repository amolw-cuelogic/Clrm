import { NgModule } from '@angular/core';

import { SkillComponent } from './skill.component';
import { SkillRoutingModule } from './skill-routing.module';

import { SharedModule } from '../../../shared.module'

@NgModule({
    imports: [
        SkillRoutingModule,
        SharedModule
    ],
    declarations: [SkillComponent]
})
export class SkillModule {

    
}
