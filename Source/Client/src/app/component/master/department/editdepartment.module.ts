import { NgModule } from '@angular/core';

import { EditDepartmentComponent } from './editdepartment.component';
import { EditDepartmentRoutingModule } from './editdepartment-routing.module';

import { SharedModule } from '../../../shared.module'

@NgModule({
    imports: [
        EditDepartmentRoutingModule,
        SharedModule
    ],
    declarations: [EditDepartmentComponent]
})
export class EditDepartmentModule {
    
}
