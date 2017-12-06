import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import Router from '../../router/router'

@Component
export default class CounterComponent extends Vue {
    currentcount: number = 0;

    incrementCounter() {
        this.currentcount++;
        if (this.currentcount > 5)
        Router.replace('counter')    
        
    }
}
