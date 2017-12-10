import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component({
    components: {
        MultiLineComponent: require('../types/multiLine/multiLine.vue.html'),
    }
})
export default class Editor extends Vue {
    
}