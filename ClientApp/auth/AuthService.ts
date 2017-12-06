import auth0, { WebAuth } from 'auth0-js'
import {EventEmitter} from '../models/EventEmmiter'
import Router from '../router/router'


export default class AuthService {
    authenticated = this.isAuthenticated()
    auth0: WebAuth
    constructor(hostname:string, port:string, protocol:string) {
        this.login = this.login.bind(this);
        this.setSession = this.setSession.bind(this)
        this.logout = this.logout.bind(this)
        this.isAuthenticated = this.isAuthenticated.bind(this)
        var stringBuild = protocol + "//" + hostname;
        if (port !== "")
          stringBuild += ':' + port
        stringBuild += '/callback'
        this.auth0 = new auth0.WebAuth({
          domain: 'dotnextrussia.eu.auth0.com',
          clientID: 'g7saZcm47evyY3kWWP26ZxifDpxycl9h',
          redirectUri: stringBuild,
          audience: 'http://medhelp20171124063439.azurewebsites.net/',
          responseType: 'token id_token',
          scope: 'openid profile read:templates'
      });
    }
    



    login() {
        this.auth0.authorize();
    }

    handleAuthentication () {
        this.auth0.parseHash((err, authResult) => {
          if (authResult && authResult.accessToken && authResult.idToken) {
            this.setSession(authResult)
            Router.replace('home')
          } else if (err) {
            Router.replace('home')
            console.log(err)
            alert(`Error: ${err.error}. Check the console for further details.`)
          }
        })
      }

      setSession (authResult : any) {
        // Set the time that the access token will expire at
        let expiresAt = JSON.stringify(
          authResult.expiresIn * 1000 + new Date().getTime()
        )
        localStorage.setItem('access_token', authResult.accessToken)
        localStorage.setItem('id_token', authResult.idToken)
        localStorage.setItem('expires_at', expiresAt)
        EventEmitter.emit('authChange', true)
      }

      logout () {
        // Clear access token and ID token from local storage
        localStorage.removeItem('access_token')
        localStorage.removeItem('id_token')
        localStorage.removeItem('expires_at')
        //this.userProfile = null
        EventEmitter.emit('authChange', false)
        // navigate to the home route
        Router.replace('home')
      }

      isAuthenticated () {
        // Check whether the current time is past the
        // access token's expiry time
        let expiresAt = JSON.parse(localStorage.getItem('expires_at') || '{}')
        return new Date().getTime() < expiresAt
      }
}