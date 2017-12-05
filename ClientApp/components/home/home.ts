import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import { Template } from '../../models/Template';
import axios from 'axios';
import { LastOpenedDocument } from '../../models/LastOpenedDocument';
import AuthService from '../../auth/AuthService';

@Component({
  name: 'home'
})
export default class Home extends Vue {
  @Prop()
  auth: AuthService
  @Prop()
  authenticated: boolean

  templates: Template[] = [];
  lastOpenedDocs: LastOpenedDocument[] = [];
  service = axios.create({ baseURL: 'api/' });




  mounted() {
    this.service.get('templates/gettemplates')
      .then(response => {
        this.templates = response.data;
      })
      .catch(e => {
        alert(e);
      });

    this.service.get('lastopeneddocuments/lastopeneddocuments')
      .then(response => {
        this.lastOpenedDocs = response.data;
        //TODO: lastOpenedDoc.lastOpenedTime -> to date (now string)
      })
      .catch(e => {
        alert(e);
      });
  }
}