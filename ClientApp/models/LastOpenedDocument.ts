import { Template } from "./Template"

export class LastOpenedDocument {
    lastOpenedDocumentId: number;
    patient: string;
    lastOpenedTime: Date;
    templateId: number;

    //not working and I don't now why
    // public constructor() {
    //     this.lastOpenedTime = new Date(this.lastOpenedTime);
    //     alert(typeof(this.lastOpenedTime));
    // }
}