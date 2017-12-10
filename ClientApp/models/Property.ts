import { Type } from "./Type";
import { Template } from "./Template";

export class Property {
    propertyId: number;
    theme: string;
    typeId: number;
    type: Type;
    templateId: number;
    template: Template;
}