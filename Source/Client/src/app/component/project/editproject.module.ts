import { NgModule } from '@angular/core';

import { EditProjectComponent } from './editproject.component';
import { EditProjectRoutingModule } from './editproject-routing.module';

import { SharedModule } from '../../shared.module'
import { ModalModule } from 'ngx-bootstrap/modal'

@NgModule({
    imports: [
        EditProjectRoutingModule,
        SharedModule,
        ModalModule.forRoot()
    ],
    declarations: [EditProjectComponent]
})
export class EditProjectModule {

}
