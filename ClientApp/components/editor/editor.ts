import "vue-multiselect/dist/vue-multiselect.min.css";
import 'eonasdan-bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.min.css'
import 'eonasdan-bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.css'
// import 'eonasdan-bootstrap-datetimepicker/build/css/bootstrap-datetimepicker-standalone.css'
import Vue from 'vue';
import VueFormGenerator from "vue-form-generator";
import { Component, Prop } from 'vue-property-decorator';
import { ApiService } from '../../models/ApiService';
import { Template } from '../../models/Template';
import "vue-form-generator/dist/vfg.css";
import AutoSuggest from '../types/autosuggest/autosuggest';
import Multiselect from 'vue-multiselect';
import { EventEmitter } from "../../models/EventEmmiter";
import eonosdandatetimepicker from 'eonasdan-bootstrap-datetimepicker';

// register globally
Vue.component('multiselect', Multiselect)

Vue.component('fieldAutoSuggest', AutoSuggest)

Vue.component('datetimepicker', eonosdandatetimepicker);

Vue.use(VueFormGenerator)


@Component({
    components: {
        MultiLine: require('../types/multiLine/multiLine.vue.html'),
        SingleLine: require('../types/singleLine/singleLine.vue.html'),
        AutoSuggest: require('../types/autosuggest/autosuggest.vue.html')
    }
})
export default class Editor extends Vue {
    @Prop()
    templateId: number

    template: Template = new Template();

    mounted() {
        let self = this;
        EventEmitter.on('model_changed', (value : any) => {
            self.model.country = value;
        })

        ApiService.get('Templates/GetTemplateWithProperties/' + this.templateId)
            .then(response => {
                this.template = response.data
            })
            .catch(e => {
                alert(e);
            });
    }

    model: any = {
        patientName: "",
        patientBirthday: new Date(),
        visitDay: new Date(),
        speciality: "",
        doctorName: "",
        complaints: "",
        anammnesis: "",
        reccommended: ""
    }

    schema: any = {
        fields: [
            {
                type: "submit",
                buttonText: "Сохранить"
            },
            {
                type: "input",
                inputType: "text",
                model: "patientName",
                label: "ФИО пацента",
                placeholder: "Введите сюда имя пациента"
            },
            {
                type: "dateTimePicker",
                label: "Дата рождения пациента",
                model: "patientBirthday",
                dateTimePickerOptions: {
                    format: "YYYY-MM-DD"
                }
            },
            {
                type: "dateTimePicker",
                label: "Дата посещения",
                model: "visitDay",
                dateTimePickerOptions: {
                    format: "YYYY-MM-DD"
                }
            },
            {
                type: "input",
                inputType: "text",
                model: "speciality",
                label: "Специальность"
            },
            {
                type: "input",
                inputType: "text",
                model: "doctorName",
                label: "Имя доктора"
            },
            {
                type: "textArea",
                model: "complaints",
                label: "Жалобы",
                rows: 5
            },
            {
                type: "textArea",
                model: "anammnesis",
                label: "Анамнез",
                rows: 5
            },
            {
                type: "textArea",
                model: "reccommended",
                label: "Рекомендации",
                rows: 5
            },
            {
                type: "submit",
                buttonText: "Сохранить"
            }
        ]
    }
    save() {
        
    }
    formOptions: any = {
        validateAfterLoad: false,
        validateAfterChanged: false
    }
}