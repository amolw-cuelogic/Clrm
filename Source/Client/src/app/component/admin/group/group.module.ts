import { NgModule } from '@angular/core';

import { GroupComponent } from './group.component';
import { GroupRoutingModule } from './group-routing.module';

@NgModule({
  imports: [
      GroupRoutingModule
  ],
    declarations: [GroupComponent ]
})
export class GroupModule { }
