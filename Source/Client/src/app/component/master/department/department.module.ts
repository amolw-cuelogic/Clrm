import { NgModule } from '@angular/core';

import { DepartmentComponent } from './department.component';
import { DepartmentRoutingModule } from './department-routing.module';

import { SharedModule } from '../../../shared.module'

@NgModule({
    imports: [
        DepartmentRoutingModule,
        SharedModule
    ],
    declarations: [DepartmentComponent]
})
export class DepartmentModule {

    
}
