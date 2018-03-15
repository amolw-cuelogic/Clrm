import { NgModule } from '@angular/core';

import { RoleComponent } from './role.component';
import { RoleRoutingModule } from './role-routing.module';

import { SharedModule } from '../../../shared.module'

@NgModule({
    imports: [
        RoleRoutingModule,
        SharedModule
    ],
    declarations: [RoleComponent]
})
export class RoleModule {

    
}
