import { NgModule } from '@angular/core';

import { EditOrganizationRoleComponent } from './editOrganizationRole.component';
import { EditOrganizationRoleRoutingModule } from './editOrganizationRole-routing.module';

import { SharedModule } from '../../../shared.module'

@NgModule({
    imports: [
        EditOrganizationRoleRoutingModule,
        SharedModule
    ],
    declarations: [EditOrganizationRoleComponent]
})
export class EditOrganizationRoleModule {
    
}
