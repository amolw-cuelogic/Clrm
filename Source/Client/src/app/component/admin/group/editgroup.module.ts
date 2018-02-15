import { NgModule } from '@angular/core';

import { EditGroupComponent } from './editgroup.component';
import { EditGroupRoutingModule } from './editgroup-routing.module';

import { SharedModule } from '../../../shared.module'

@NgModule({
    imports: [
        EditGroupRoutingModule,
        SharedModule
    ],
    declarations: [EditGroupComponent]
})
export class EditGroupModule {

    
}
