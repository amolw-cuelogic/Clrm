import { NgModule } from '@angular/core';

import { ProjectComponent } from './project.component';
import { ProjectRoutingModule } from './project-routing.module';

import { SharedModule } from '../../shared.module'


@NgModule({
    imports: [
        ProjectRoutingModule,
        SharedModule
    ],
    declarations: [ProjectComponent]
})
export class ProjectModule {
    
}
