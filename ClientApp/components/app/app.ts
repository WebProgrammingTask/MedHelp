import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import AuthService from '../../auth/AuthService';



const auth = new AuthService(window.location.hostname, window.location.port, window.location.protocol)

var { login, logout, authenticated, authNotifier } = auth

export default Vue.extend({
    name: 'app',
    // components: {
    //     MenuComponent: require('../navmenu/navmenu.vue.html')
    // },
    data() {
        authNotifier.on('authChange', (authState:any) => {
            authenticated = authState.authenticated
        })
        return {
            auth,
            authenticated
        }
    },
    methods: {
        login,
        logout
    }
})