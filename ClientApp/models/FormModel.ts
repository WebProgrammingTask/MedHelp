module MedHelp.Models {
    export class FormModel {
        public patientName: string;
        public patientBirthday: Date;
        public visitDay: Date;
        public medicines: String[];
        public complaints: string;
        public speciality: string;
        public doctorName: string;
        public anamnesis: string;
        public recommended: string;
    }
}