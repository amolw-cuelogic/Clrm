import { NgModule } from '@angular/core';

//Directive
import { RightsDirective } from "./directive/rights-directive"

@NgModule({
    declarations: [RightsDirective],
    exports: [
        RightsDirective
    ]
})
export class CommonAppModule {
    

}
