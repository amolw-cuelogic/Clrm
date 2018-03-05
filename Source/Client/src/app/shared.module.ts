import { NgModule } from '@angular/core';

import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

//Directive
import { LabelDirective } from "./directive/label-directive"
import { CommonAppModule } from './common.module'

@NgModule({
    imports: [CommonAppModule],
    declarations: [LabelDirective],
    exports: [
        LabelDirective,
        CommonModule,
        FormsModule,
        CommonAppModule
    ]
})
export class SharedModule {


}
