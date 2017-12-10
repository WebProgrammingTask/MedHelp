import "vue-multiselect/dist/vue-multiselect.min.css";
import Vue from 'vue';
import VueFormGenerator from "vue-form-generator";
import { Component, Prop } from 'vue-property-decorator';
import { ApiService } from '../../models/ApiService';
import { Template } from '../../models/Template';
import "vue-form-generator/dist/vfg.css";
import AutoSuggest from '../types/autosuggest/autosuggest';
import Multiselect from 'vue-multiselect';
import { EventEmitter } from "../../models/EventEmmiter";

// register globally
Vue.component('multiselect', Multiselect)

Vue.component('fieldAutoSuggest', AutoSuggest)

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
        id: 1,
        name: "John Doe",
        password: "J0hnD03!x4",
        skills: ["Javascript", "VueJS"],
        email: "john.doe@gmail.com",
        status: true,
        suggest: 1,
        country: [],
    }

    schema: any = {
        fields: [
            {
                model: "country",
                type: "vueMultiSelect",
                label: "Country",
                placeholder: "Select a country",
                values: [1, 2, 3],
                options: [],
                selectOptions: {
                    multiple: true,
                    hideselected: true,
                    multiSelect: true,
                    closeOnSelect: true,
                    showLabels: false,
                    searchable: true,
                    taggable: true,
                    limit: 10,
                    sel: this,
                    onNewTag: function (newTag : any, id: any, options: any, value: any) {
                        EventEmitter.emit('model_changed', value);
                    }
                }
            },
            {
                type: "AutoSuggest",
                label: "Serega",
                model: "suggest"
            },
            {
                type: "input",
                inputType: "text",
                label: "ID",
                model: "id",
                inputName: "id",
                readonly: true,
                featured: false,
                disabled: true
            },
            {
                type: "input",
                inputType: "text",
                label: "Name",
                model: "name",
                inputName: "name",
                readonly: false,
                featured: true,
                required: true,
                disabled: false,
                placeholder: "User's name",
                //validator: VueFormGenerator.validators.string
            },
            {
                type: "input",
                inputType: "password",
                label: "Password",
                model: "password",
                inputName: "password",
                min: 6,
                required: true,
                hint: "Minimum 6 characters",
                //validator: VueFormGenerator.validators.string
            },
            {
                type: "input",
                inputType: "email",
                label: "E-mail",
                model: "email",
                inputName: "email",
                placeholder: "User's e-mail address",
                //validator: VueFormGenerator.validators.email
            },
            {
                type: "select",
                label: "Skills",
                model: "skills",
                inputName: "skills",
                required: true,
                values: [
                    "HTML5",
                    "Javascript",
                    "CSS3",
                    "CoffeeScript",
                    "AngularJS",
                    "ReactJS",
                    "VueJS"
                ],
                //validator: VueFormGenerator.validators.string
            },
            {
                type: "upload",
                label: "Photo",
                model: "photo",
                inputName: "photo",
            },
            {
                type: "checkbox",
                label: "Status",
                model: "status",
                inputName: "status",
                multi: true,
                readonly: false,
                featured: false,
                disabled: false,
                default: true
            },
            {
                type: "AutoSuggest",
                label: "Awesome (custom field)",
            },
            {
                type: "submit",
                label: "",
                buttonText: "Submit",
                validateBeforeSubmit: true
            }


        ]
    }

    formOptions: any = {
        validateAfterLoad: false,
        validateAfterChanged: false
    }
}