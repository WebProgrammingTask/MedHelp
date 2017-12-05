import Vue from "vue";
import { Component, Prop } from "vue-property-decorator";
import AuthService from "../../auth/AuthService";


@Component({
  name: 'callback'
})
export default class Callback extends Vue {
  @Prop()
  auth: AuthService
  data(){
    this.auth.handleAuthentication()
  }
}