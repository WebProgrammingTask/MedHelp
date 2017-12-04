import Vue from "vue";

export default Vue.extend({
    name: 'callback',
    props: ['auth'],
    data () {
      // alert(JSON.stringify(this.auth))
      this.auth.handleAuthentication()
      return {}
    }
  })