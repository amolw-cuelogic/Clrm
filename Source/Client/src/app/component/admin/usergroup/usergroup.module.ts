import { NgModule } from '@angular/core';

import { UserGroupComponent } from './usergroup.component';
import { UserGroupRoutingModule } from './usergroup-routing.module';

import { SharedModule } from '../../../shared.module'
import { ModalModule } from 'ngx-bootstrap/modal'

@NgModule({
    imports: [
        UserGroupRoutingModule,
        SharedModule,
        ModalModule.forRoot()
    ],
    declarations: [UserGroupComponent]
})
export class UserGroupModule {

}
