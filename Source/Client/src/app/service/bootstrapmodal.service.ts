import { Injectable } from '@angular/core';
import { BootstrapModel } from '../model/bootstrapmodel'
import * as $ from 'jquery';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class BootstrapmodalService {

    private messageSource = new BehaviorSubject<BootstrapModel>(new BootstrapModel());
    Listen = this.messageSource.asObservable();

    constructor() { }

    Open(objModel: BootstrapModel) {
        this.messageSource.next(objModel)
        $('body').addClass('modal-open');
        $('#idGlobalErrorModal').addClass('show');
        $('#idGlobalErrorModal').css({ 'display': 'block' });
    }

}
