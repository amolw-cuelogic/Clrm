import { NgModule } from '@angular/core';

import { AllocationComponent } from './allocation.component';
import { AllocationRoutingModule } from './allocation-routing.module';

import { SharedModule } from '../../shared.module'


@NgModule({
    imports: [
        AllocationRoutingModule,
        SharedModule
    ],
    declarations: [AllocationComponent]
})
export class AllocationModule {
    
}
