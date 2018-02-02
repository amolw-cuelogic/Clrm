export class BootstrapModel {

    constructor() {
        this.ModelType = new ModelType();
        this.Title = "";
        this.Message = "";
        this.MessageType = "";
    }

    Title: string;
    Message: string;
    MessageType: string;
    ModelType: ModelType;

    
}

export class ModelType {
    Danger: string = "danger";
    Warning: string = "warning";
    Success: string = "success";
    Info: string = "info"
}
