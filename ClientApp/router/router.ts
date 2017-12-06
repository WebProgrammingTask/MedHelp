import Vue from 'vue'
import Router from 'vue-router'
import Home from '../components/home/home'
import Callback from '../components/callback/callback'

Vue.use(Router)

const router = new Router({
    mode: 'history',
    routes: [
        {
            path: '/home',
            name: 'Home',
            component: Home
        },
        {
            path: '/callback',
            name: 'Callback',
            component: Callback
        },
        {
            path: '*',
            redirect: '/home'
        },
        { path: '/', component: require('../components/home/home.vue.html') },
        { path: '/callback', component: require('../components/callback/callback.vue.html') },        
        { path: '/counter', component: require('../components/counter/counter.vue.html') },
        { path: '/fetchdata', component: require('../components/fetchdata/fetchdata.vue.html') }
    ]
})

export default router
