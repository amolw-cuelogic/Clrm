import { NgModule } from '@angular/core';

import { OrganizationRoleComponent } from './organizationRole.component';
import { OrganizationRoleRoutingModule } from './organizationRole-routing.module';

import { SharedModule } from '../../../shared.module'

@NgModule({
    imports: [
        OrganizationRoleRoutingModule,
        SharedModule
    ],
    declarations: [OrganizationRoleComponent]
})
export class OrganizationRoleModule {

    
}
