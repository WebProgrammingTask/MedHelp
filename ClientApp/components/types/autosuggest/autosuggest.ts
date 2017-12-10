import Vue from 'vue'
import { BasicSelect } from 'vue-search-select'

import { abstractField } from 'vue-form-generator'
import { Component } from 'vue-property-decorator';

@Component({
    mixins: [abstractField],
    components: { BasicSelect }

})
export default class AutoSuggest extends Vue {
    options: any = [
        { value: '1', text: 'aa' + ' - ' + '1' },
        { value: '2', text: 'ab' + ' - ' + '2' },
        { value: '3', text: 'bc' + ' - ' + '3' },
        { value: '4', text: 'cd' + ' - ' + '4' },
        { value: '5', text: 'de' + ' - ' + '5' }
    ]
    searchText: any = ''
    item: any = {
        value: '',
        text: ''
    }


    reset() {
        this.item = {}
    }
    onSelect(item: any) {
        this.item = item
    }
    selectOption() {
        // select option from parent component
        this.item = this.options[0]
    }
}
