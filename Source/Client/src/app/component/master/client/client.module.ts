import { NgModule } from '@angular/core';

import { ClientComponent } from './client.component';
import { ClientRoutingModule } from './client-routing.module';

import { SharedModule } from '../../../shared.module'

@NgModule({
    imports: [
        ClientRoutingModule,
        SharedModule
    ],
    declarations: [ClientComponent]
})
export class ClientModule {

    
}
