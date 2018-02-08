import { NgModule } from '@angular/core';

import { EditGroupComponent } from './editgroup.component';
import { EditGroupRoutingModule } from './editgroup-routing.module';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
    imports: [
        EditGroupRoutingModule,
        CommonModule,
        FormsModule
    ],
    declarations: [EditGroupComponent]
})
export class EditGroupModule {

    
}
