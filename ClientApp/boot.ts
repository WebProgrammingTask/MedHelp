import './css/site.css';
import 'bootstrap';
import Vue from 'vue';
import VueRouter from 'vue-router';
import router from './router'
import App from './components/app/app'
Vue.use(VueRouter);


new Vue({
    el: '#app-root',
    router: router,
    render: h => h(require('./components/app/app.vue.html'))
});
