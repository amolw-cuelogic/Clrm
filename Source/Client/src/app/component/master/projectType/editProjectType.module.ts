import { NgModule } from '@angular/core';

import { EditProjectTypeComponent } from './editProjectType.component';
import { EditProjectTypeRoutingModule } from './editProjectType-routing.module';

import { SharedModule } from '../../../shared.module'

@NgModule({
    imports: [
        EditProjectTypeRoutingModule,
        SharedModule
    ],
    declarations: [EditProjectTypeComponent]
})
export class EditProjectTypeModule {
    
}
