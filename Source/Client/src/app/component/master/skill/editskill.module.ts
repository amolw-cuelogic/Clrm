import { NgModule } from '@angular/core';

import { EditSkillComponent } from './editskill.component';
import { EditSkillRoutingModule } from './editskill-routing.module';

import { SharedModule } from '../../../shared.module'

@NgModule({
    imports: [
        EditSkillRoutingModule,
        SharedModule
    ],
    declarations: [EditSkillComponent]
})
export class EditSkillModule {

}
