import { NgModule } from '@angular/core';

import { GroupComponent } from './group.component';
import { GroupRoutingModule } from './group-routing.module';

import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
    imports: [
        GroupRoutingModule,
        CommonModule
    ],
    declarations: [GroupComponent]
})
export class GroupModule {

    
}
