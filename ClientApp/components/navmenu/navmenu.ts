import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import AuthService from '../../auth/AuthService';

@Component
export default class NavMenu extends Vue {
    @Prop()
    auth: AuthService
}