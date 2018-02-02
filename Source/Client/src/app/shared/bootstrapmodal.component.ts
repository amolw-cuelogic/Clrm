import { Component, OnInit, NgZone } from '@angular/core';
import { BootstrapModel } from '../model/bootstrapmodel'
import { BootstrapmodalService } from '../service/bootstrapmodal.service'
import * as $ from 'jquery';

@Component({
    selector: 'global-bootstrapmodal',
    templateUrl: './bootstrapmodal.component.html'
})
export class BootstrapmodalComponent implements OnInit {

    bootstrapModal: any = new Object();

    constructor(private srvBootstrapModal: BootstrapmodalService, private zone: NgZone) {
        
        
    }

    ngAfterViewInit() {
      

        this.srvBootstrapModal.Listen.subscribe(message => {
            if ('Message' in message) {
                //this.bootstrapModal = new BootstrapModel();
                this.zone.run(() => {
                    this.bootstrapModal = message;
                });
            }
        });
    }

    ngOnInit() {
        this.bootstrapModal.Title = "";
        this.bootstrapModal.Message = "";
        this.bootstrapModal.MessageType = "";
    }


    Close() {
        $('body').removeClass('modal-open');
        $('#idGlobalErrorModal').removeClass('show');
        $('#idGlobalErrorModal').css({ 'display': 'none' });
    }

}
