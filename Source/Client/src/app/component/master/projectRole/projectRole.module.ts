import { NgModule } from '@angular/core';

import { ProjectRoleComponent } from './projectRole.component';
import { ProjectRoleRoutingModule } from './projectRole-routing.module';

import { SharedModule } from '../../../shared.module'

@NgModule({
    imports: [
        ProjectRoleRoutingModule,
        SharedModule
    ],
    declarations: [ProjectRoleComponent]
})
export class ProjectRoleModule {

    
}
