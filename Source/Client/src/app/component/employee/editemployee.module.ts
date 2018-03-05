import { NgModule } from '@angular/core';

import { EditEmployeeComponent } from './editemployee.component';
import { EditEmployeeRoutingModule } from './editemployee-routing.module';

import { SharedModule } from '../../shared.module'
import { ModalModule } from 'ngx-bootstrap/modal'

@NgModule({
    imports: [
        EditEmployeeRoutingModule,
        SharedModule,
        ModalModule.forRoot()
    ],
    declarations: [EditEmployeeComponent]
})
export class EditEmployeeModule {

}
