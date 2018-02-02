import { ErrorHandler, Injectable } from '@angular/core';
import { ComponentSubscriptionService } from './componentsubscription.service'
import { BootstrapModel } from '../model/bootstrapmodel'

@Injectable()
export class ErrorhandlerService implements ErrorHandler {
    constructor(private srvCompSub: ComponentSubscriptionService) { }
    handleError(error) {

        var model = new BootstrapModel();
        model.Title = "Error";
        model.MessageType = model.ModelType.Danger;
        if ('_body' in error) {
            var errorJson = error['_body'];
            try {
                var errorString = error['_body'] as string;
                var errorObject = JSON.parse(errorString);
                if ('error_description' in errorObject) {
                    model.Message = errorObject['error_description'] as string;
                }
            }
            catch (ex) {

            }
        }
        else if ('message' in error) {
            model.Message = error.message;
        }
        else if ('error' in error) {
            model.Message = error.error;
            model.Title = "Info";
            model.MessageType = model.ModelType.Info;
        }
        else {
            model.Message = "Error occured";
        }

        this.srvCompSub.OpenBootstrapModal(model);
        console.log(error)
        // IMPORTANT: Rethrow the error otherwise it gets swallowed
        //throw error;
    }

}