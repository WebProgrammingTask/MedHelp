import { Property } from "./Property";
import FormModel = MedHelp.Models.FormModel;

export class Template {
    templateId: number;
    name: string;
    description: string;
    imagePath: string;
    schemeJson: string;
    modelJson: string;
    formModel: FormModel;
}