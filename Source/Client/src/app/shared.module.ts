import { NgModule } from '@angular/core';

import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

//Directive
import { LabelDirective } from "./directive/label-directive"

@NgModule({
    declarations: [LabelDirective],
    exports: [
        LabelDirective,
        CommonModule,
        FormsModule
    ]
})
export class SharedModule {


}
