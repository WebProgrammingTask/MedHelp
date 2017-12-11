import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { EventEmitter } from '../../models/EventEmmiter'
import AuthService from '../../auth/AuthService';

const auth = new AuthService(window.location.hostname, window.location.port, window.location.protocol)

var { login, logout } = auth

@Component({
    name: 'app',
    components: {
        MenuComponent: require('../navmenu/navmenu.vue.html')
    },
    methods: {
        login,
        logout
    },
    data() {
        EventEmitter.on('authChange', (authState: boolean) => {
            auth.authenticated = authState;
        })
        return {
            auth
        }
    }
})
export default class App extends Vue {
}