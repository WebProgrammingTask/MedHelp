import { Property } from "./Property";

export class Template {
    templateId: number;
    name: string;
    description: string;
    imagePath: string;
    schemeJson: string;
    modelJson: string;
    properties: Property[];
}