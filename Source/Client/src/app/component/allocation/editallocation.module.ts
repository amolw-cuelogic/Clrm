import { NgModule } from '@angular/core';

import { EditAllocationComponent } from './editallocation.component';
import { EditAllocationRoutingModule } from './editallocation-routing.module';

import { SharedModule } from '../../shared.module'
import { ModalModule } from 'ngx-bootstrap/modal'

@NgModule({
    imports: [
        EditAllocationRoutingModule,
        SharedModule,
        ModalModule.forRoot()
    ],
    declarations: [EditAllocationComponent]
})
export class EditAllocationModule {

}
