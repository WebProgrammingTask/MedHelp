import auth0, { WebAuth } from 'auth0-js'
import router from '../router/'
import EventEmitter from 'EventEmitter'

export default class AuthService {
    authenticated = this.isAuthenticated()
    authNotifier = new EventEmitter()
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
            router.replace('home')
          } else if (err) {
            router.replace('home')
            console.log(err)
            alert(`Error: ${err.error}. Check the console for further details.`)
          }
          location.reload()          
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
        this.authNotifier.emit('authChange', { authenticated: true })
      }

      logout () {
        // Clear access token and ID token from local storage
        localStorage.removeItem('access_token')
        localStorage.removeItem('id_token')
        localStorage.removeItem('expires_at')
        //this.userProfile = null
        this.authNotifier.emit('authChange', false)
        // navigate to the home route
        router.replace('home')
        location.reload()
      }

      isAuthenticated () {
        // Check whether the current time is past the
        // access token's expiry time
        let expiresAt = JSON.parse(localStorage.getItem('expires_at') || '{}')
        return new Date().getTime() < expiresAt
      }
}