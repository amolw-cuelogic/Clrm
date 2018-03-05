import { Injectable } from '@angular/core';
import { BootstrapModel } from '../model/bootstrapmodel'
import * as $ from 'jquery';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class CommonService {

    ShowBootstrapModal(id: any) {
        $('body').addClass('modal-open');
        $('#'+id).addClass('show');
        $('#' + id).css({ 'display': 'block' });
    }

    HideBootstrapModal(id: any) {
        $('body').removeClass('modal-open');
        $('#' + id).removeClass('show');
        $('#' + id).css({ 'display': 'none' });
    }

}