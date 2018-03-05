import { NgModule } from '@angular/core';

import { EditClientComponent } from './editclient.component';
import { EditClientRoutingModule } from './editclient-routing.module';

import { SharedModule } from '../../../shared.module'

@NgModule({
    imports: [
        EditClientRoutingModule,
        SharedModule
    ],
    declarations: [EditClientComponent]
})
export class EditClientModule {
    
}
