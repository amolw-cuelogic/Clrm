import { NgModule } from '@angular/core';

import { UserGroupComponent } from './usergroup.component';
import { UserGroupRoutingModule } from './usergroup-routing.module';

@NgModule({
  imports: [
      UserGroupRoutingModule
  ],
    declarations: [UserGroupComponent ]
})
export class UserGroupModule { }
