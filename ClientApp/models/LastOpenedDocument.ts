import {Template} from "./Template"

export class LastOpenedDocument {
    patient: string;
    lastOpenedTime: Date;
    template: Template;

    //not working and I don't now why
    // public constructor() {
    //     this.lastOpenedTime = new Date(this.lastOpenedTime);
    //     alert(typeof(this.lastOpenedTime));
    // }
}