import { Injectable } from '@angular/core';
import { BootstrapModel } from '../model/bootstrapmodel'
import * as $ from 'jquery';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class ComponentSubscriptionService {

    private bootstrapModalMessageSource = new BehaviorSubject<BootstrapModel>(new BootstrapModel());
    ListenBootstrapModal = this.bootstrapModalMessageSource.asObservable();

    constructor() { }

    OpenBootstrapModal(objModel: BootstrapModel) {
        this.bootstrapModalMessageSource.next(objModel)
        $('body').addClass('modal-open');
        $('#idGlobalErrorModal').addClass('show');
        $('#idGlobalErrorModal').css({ 'display': 'block' });
    }

    OpenToaster(objModel: BootstrapModel) {
        this.bootstrapModalMessageSource.next(objModel)
        var x = document.getElementById("toast")
        x.className = "show";
        setTimeout(function () { x.className = x.className.replace("show", ""); }, 1600);
    }

}
