import { NgModule } from '@angular/core';

import { GroupComponent } from './group.component';
import { GroupRoutingModule } from './group-routing.module';

import { SharedModule } from '../../../shared.module'

@NgModule({
    imports: [
        GroupRoutingModule,
        SharedModule
    ],
    declarations: [GroupComponent]
})
export class GroupModule {

    
}
