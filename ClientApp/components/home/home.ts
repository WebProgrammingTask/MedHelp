import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import { Template } from '../../models/Template';
import { ApiService } from '../../models/ApiService'
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




  mounted() {
    ApiService.get('templates/gettemplates')
      .then(response => {
        this.templates = response.data;
      })
      .catch(e => {
        alert(e);
      });

    ApiService.get('lastopeneddocuments/lastopeneddocuments')
      .then(response => {
        this.lastOpenedDocs = response.data;
        //TODO: lastOpenedDoc.lastOpenedTime -> to date (now string)
      })
      .catch(e => {
        alert(e);
      });
  }
}