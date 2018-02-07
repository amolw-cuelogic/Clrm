import { NgModule } from '@angular/core';

import { GroupComponent } from './group.component';
import { GroupRoutingModule } from './group-routing.module';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
    imports: [
        GroupRoutingModule,
        CommonModule,
        FormsModule
    ],
    declarations: [GroupComponent]
})
export class GroupModule {

    
}
