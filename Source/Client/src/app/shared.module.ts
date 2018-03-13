import { NgModule } from '@angular/core';

import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

//Directive
import { LabelDirective } from "./directive/label-directive"
import { CommonAppModule } from './common.module'

import { FilterPipe } from './filter/filter.pipe'

@NgModule({
    imports: [CommonAppModule],
    declarations: [LabelDirective, FilterPipe],
    exports: [
        LabelDirective,
        CommonModule,
        FormsModule,
        CommonAppModule,
        FilterPipe
    ]
})
export class SharedModule {


}
