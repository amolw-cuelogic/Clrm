import { NgModule } from '@angular/core';

import { EditEmployeeComponent } from './editemployee.component';
import { EditEmployeeRoutingModule } from './editemployee-routing.module';

import { SharedModule } from '../../shared.module'

@NgModule({
    imports: [
        EditEmployeeRoutingModule,
        SharedModule
    ],
    declarations: [EditEmployeeComponent]
})
export class EditEmployeeModule {

}
