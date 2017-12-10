import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import { ApiService } from '../../models/ApiService';
import { Template } from '../../models/Template';

@Component({
    components: {
        MultiLine: require('../types/multiLine/multiLine.vue.html'),
        SingleLine: require('../types/singleLine/singleLine.vue.html')
    },
})
export default class Editor extends Vue {
    @Prop()
    templateId: number

    template: Template = new Template();

    mounted() {
        ApiService.get('Templates/GetTemplateWithProperties/' + this.templateId)
            .then(response => {
                this.template = response.data
            })
            .catch(e => {
                alert(e);
            });
    }

}