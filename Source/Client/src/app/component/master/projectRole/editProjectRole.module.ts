import { NgModule } from '@angular/core';

import { EditProjectRoleComponent } from './editProjectRole.component';
import { EditProjectRoleRoutingModule } from './editProjectRole-routing.module';

import { SharedModule } from '../../../shared.module'

@NgModule({
    imports: [
        EditProjectRoleRoutingModule,
        SharedModule
    ],
    declarations: [EditProjectRoleComponent]
})
export class EditProjectRoleModule {
    
}
