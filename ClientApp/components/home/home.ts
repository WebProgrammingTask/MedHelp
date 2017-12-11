import Vue from 'vue';
import { Component, Prop, Watch } from 'vue-property-decorator';
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

  templates: Template[] = [];
  lastOpenedDocs: LastOpenedDocument[] = [];

  getTemplates() {
    ApiService.get('templates/gettemplates')
      .then(response => {
        this.templates = response.data;
      })
      .catch(e => {
        alert(e);
      });
  }

  getLastOpenedDocs() {
    ApiService.get('lastopeneddocuments/getlastopeneddocuments')
      .then(response => {
        this.lastOpenedDocs = response.data;
        //TODO: lastOpenedDoc.lastOpenedTime -> to date (now string)
      })
      .catch(e => {
        alert(e);
      });
  }


  mounted() {
    if (this.auth.authenticated) {
      this.getTemplates();
      this.getLastOpenedDocs();
    }
  }
}