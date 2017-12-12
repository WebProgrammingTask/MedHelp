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
import Multiselect from 'vue-multiselect';
import { EventEmitter } from "../../models/EventEmmiter";
import eonosdandatetimepicker from 'eonasdan-bootstrap-datetimepicker';
import { LastOpenedDocument } from "../../models/LastOpenedDocument";
import { VueRouter } from "vue-router/types/router";

// register globally
Vue.component('multiselect', Multiselect)

Vue.component('datetimepicker', eonosdandatetimepicker);

Vue.use(VueFormGenerator)


@Component
export default class Editor extends Vue {
    @Prop()
    templateId: number
    @Prop()
    lastOpenedDocumentId: number


    template: Template = new Template();
    medicines: any = []
    model: any = {};
    schema: any = {};

    mounted() {
        let self = this;
        EventEmitter.on('model_changed', (value: any) => {
            self.model.medicines = value;
            self.schema.fields[9].values = self.medicines;
        })


        ApiService.get('Templates/GetTemplateWithProperties/' + this.templateId)
            .then(response => {
                this.template = response.data;
                if (self.lastOpenedDocumentId == null) {
                    this.model = response.data.formModel;//JSON.parse(response.data.modelJson);
                    ApiService.get('Medicines/GetMedicines').then(response =>
                    {
                        self.model.medicines = response.data;
                    });
                }

                this.schema = JSON.parse(response.data.schemeJson);
                ApiService.get('medicine/getmedicines')
                    .then(response => {
                        self.medicines = response.data
                        self.schema.fields[9].values = self.medicines;
                        self.schema.fields[9].selectOptions.onNewTag = function (newTag: any, id: any, options: any, value: any) {
                            EventEmitter.emit('model_changed', value);
                        }
                    })
                    .catch(e => {
                        alert(e);
                    });
            })
            .catch(e => {
                alert(e);
            });

        if (this.lastOpenedDocumentId != null) {
            ApiService.get('LastOpenedDocuments/GetLastOpenedDocument/' + this.lastOpenedDocumentId)
                .then(response => {
                    this.model = JSON.parse(response.data.modelJson);
                    console.log(
                        this.model = JSON.parse(response.data.modelJson));
                })
                .catch(e => {
                    alert(e);
                });
        }

    }
    
    save() {
        var self = this;
        var newLastOpenedDocument = new LastOpenedDocument();
        newLastOpenedDocument.lastOpenedTime = new Date();
        newLastOpenedDocument.modelJson = JSON.stringify(this.model);
        newLastOpenedDocument.templateId = this.templateId;
        newLastOpenedDocument.patient = this.model.patientName;
        if (this.lastOpenedDocumentId == null) {
            ApiService.post('LastOpenedDocuments/InsertNewLastOpenedDocument')
                .then(response => {
                    this.$router.replace('editor?lastOpenedDocumentId=' + response.data + "&templateId=" + this.templateId);
                    this.lastOpenedDocumentId = response.data;
                    console.log(response);
                })
                .catch(e => {
                    console.log(e);
                })
        }
        else {
            newLastOpenedDocument.lastOpenedDocumentId = this.lastOpenedDocumentId;
            ApiService.put('LastOpenedDocuments/UpdateDocument/' + this.lastOpenedDocumentId, newLastOpenedDocument)
                .then(response => {
                    console.log(response);
                })
                .catch(e => {
                    console.log(e);
                })
        }
    }

    formOptions: any = {
        validateAfterLoad: false,
        validateAfterChanged: false
    }
}