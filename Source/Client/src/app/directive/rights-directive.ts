import { Directive, ElementRef } from '@angular/core'
import { AppconfigService } from '../service/appconfig.service'

@Directive({
    selector: "[ngx-rights]"
})
export class RightsDirective {

    Remove() {
        this.el.nativeElement.remove();
    }

    constructor(private el: ElementRef, private appConfigService: AppconfigService) {
        var value = this.el.nativeElement.attributes["ngx-rights"].value;
        var valueArray = value.split("|");

        if (valueArray[0].indexOf(",") == -1) {
            var rights = this.appConfigService.GetRights(valueArray[0]);
            if (rights == null)
                return;
            if (valueArray[1] == "Read") {
                if (rights.Read == false)
                    this.Remove();
            }
            else if (valueArray[1] == "Write") {
                if (rights.Write == false)
                    this.Remove();
            }
            else {
                if (rights.Delete == false)
                    this.Remove();
            }
        }
        else {
            var rightIdArray = valueArray[0].split(",");
            var falseCount = 0;
            for (var i = 0; i < rightIdArray.length; i++) {
                var rights = this.appConfigService.GetRights(rightIdArray[i]);
                if (valueArray[1] == "Read") {
                    if (rights.Read == false)
                        falseCount++
                }
            }
            if (rightIdArray.length == falseCount)
                this.Remove();
        }
    }

}