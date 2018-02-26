import { NgModule } from '@angular/core';

import { ProjectTypeComponent } from './projectType.component';
import { ProjectTypeRoutingModule } from './projectType-routing.module';

import { SharedModule } from '../../../shared.module'

@NgModule({
    imports: [
        ProjectTypeRoutingModule,
        SharedModule
    ],
    declarations: [ProjectTypeComponent]
})
export class ProjectTypeModule {

    
}
