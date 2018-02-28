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

        if (StringifiedError.indexOf("<clrm>") > -1)
        {
            var errorString = StringifiedError.split('<clrm>').pop().split('</clrm>').shift();
            var message = errorString.split('|');
            var key = message[0].trim();
            if (key == "Error") {
                model.MessageType = model.ModelType.Danger;
                model.Title = "Error";
            }
            if (key == "Success") {
                model.MessageType = model.ModelType.Success;
                model.Title = "Success";
            }
            if (key == "Warning") {
                model.MessageType = model.ModelType.Warning;
                model.Title = "Warning";
            }
            if (key == "Information") {
                model.MessageType = model.ModelType.Info;
                model.Title = "Information";
            }
            model.Message = message[1].trim();
        }

        this.srvCompSub.OpenBootstrapModal(model);
        console.log(error)
    }

}
