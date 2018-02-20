import { Component, OnInit, NgZone } from '@angular/core';
import { BootstrapModel } from '../model/bootstrapmodel'
import { ComponentSubscriptionService } from '../service/componentsubscription.service'
import * as $ from 'jquery';

@Component({
    selector: 'global-bootstrapmodal',
    templateUrl: './bootstrapmodal.component.html'
})
export class BootstrapmodalComponent implements OnInit {

    bootstrapModal: any = new Object();

    constructor(private srvCompSub: ComponentSubscriptionService, private zone: NgZone) {
        
        
    }

    ngAfterContentInit () {
      

        this.srvCompSub.ListenBootstrapModal.subscribe(message => {
            if ('Message' in message) {
                //This is added in order to bind it to the expression (one way data binding)
                //Solution if does not work first time
                this.zone.run(() => {
                    this.bootstrapModal = message;
                });
            }
        });
    }

    ngOnInit() {
   
    }

    Close() {
        $('body').removeClass('modal-open');
        $('#idGlobalErrorModal').removeClass('show');
        $('#idGlobalErrorModal').css({ 'display': 'none' });
    }

}
