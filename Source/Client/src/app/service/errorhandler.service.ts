import { ErrorHandler, Injectable } from '@angular/core';
import { ComponentSubscriptionService } from './componentsubscription.service'
import { BootstrapModel } from '../model/bootstrapmodel'
import { isDevMode } from '@angular/core';

@Injectable()
export class ErrorhandlerService implements ErrorHandler {
    constructor(private srvCompSub: ComponentSubscriptionService) { }
    handleError(error) {

        var StringifiedError = JSON.stringify(error);

        var model = new BootstrapModel();
        model.Title = "Error";
        model.MessageType = model.ModelType.Danger;
        
        if (isDevMode()) {
            model.Message = StringifiedError;
        }
        else {
            model.Message = "Something went wrong";
        }
        this.srvCompSub.OpenBootstrapModal(model);
        console.log(error)
        // IMPORTANT: Rethrow the error otherwise it gets swallowed
        //throw error;
    }

}
