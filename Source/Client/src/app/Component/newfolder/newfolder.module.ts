import { NgModule } from '@angular/core';
import { ChartsModule } from 'ng2-charts/ng2-charts';

import { NewfolderComponent } from './newfolder.component';
import { NewfolderRoutingModule } from './newfolder-routing.module';

@NgModule({
  imports: [
      NewfolderRoutingModule,
    ChartsModule
  ],
    declarations: [NewfolderComponent ]
})
export class NewfolderModule { }
