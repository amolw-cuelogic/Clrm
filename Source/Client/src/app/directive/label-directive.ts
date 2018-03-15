import { Directive, ElementRef } from '@angular/core'

@Directive({
    selector:"ngx-label"
})
export class LabelDirective {

    constructor(private el: ElementRef) {
        var text = this.el.nativeElement.attributes["value"].value;
        var sup = document.createElement("sup");
        sup.innerText = "*";
        sup.style.cssText = "color:red; font-size:15px;top: 0.0em;font-weight:bold;margin-left:2px;";
        var span = document.createElement("label");
        span.innerText = text;
        span.appendChild(sup);
        this.el.nativeElement.append(span);
    }

}