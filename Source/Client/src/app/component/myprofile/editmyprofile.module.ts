import { NgModule } from '@angular/core';

import { EditMyProfileComponent } from './editmyprofile.component';
import { EditMyProfileRoutingModule } from './editmyprofile-routing.module';

import { SharedModule } from '../../shared.module'
import { ModalModule } from 'ngx-bootstrap/modal'

@NgModule({
    imports: [
        EditMyProfileRoutingModule,
        SharedModule,
        ModalModule.forRoot()
    ],
    declarations: [EditMyProfileComponent]
})
export class EditMyProfileModule {

}
