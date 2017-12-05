import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { Template } from '../../models/Template';
import axios from 'axios';
import { LastOpenedDocument } from '../../models/LastOpenedDocument';

@Component
export default class Home extends Vue {
  name: 'home';
  props: ['auth', 'authenticated'];
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