import { NgModule } from '@angular/core';

import { EmployeeComponent } from './employee.component';
import { EmployeeRoutingModule } from './employee-routing.module';

import { SharedModule } from '../../../shared.module'


@NgModule({
    imports: [
        EmployeeRoutingModule,
        SharedModule
    ],
    declarations: [EmployeeComponent]
})
export class EmployeeModule {
    
}
