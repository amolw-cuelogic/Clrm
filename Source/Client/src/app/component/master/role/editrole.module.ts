import { NgModule } from '@angular/core';

import { EditRoleComponent } from './editrole.component';
import { EditRoleRoutingModule } from './editrole-routing.module';

import { SharedModule } from '../../../shared.module'

@NgModule({
    imports: [
        EditRoleRoutingModule,
        SharedModule
    ],
    declarations: [EditRoleComponent]
})
export class EditRoleModule {
    
}
