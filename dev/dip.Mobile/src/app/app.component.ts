import { Component } from '@angular/core';
import { Platform } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';

import { NativeStorage } from '@ionic-native/native-storage';
import { LoginPage } from './login/login.page';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html'
})
export class AppComponent {
  constructor(
    private platform: Platform,
    private splashScreen: SplashScreen,
    private statusBar: StatusBar,
    //private navCtrl: NavController
    //private nativeStorage: NativeStorage
  ) 
  {
    this.initializeApp();
  }

  initializeApp() {

    this.platform.ready().then(() => {

      // Here we will check if the user is already logged in
      // because we don't want to ask users to log in each time they open the app
      let env = this;

      //this.nativeStorage.getItem('user')
      //.then( function (data) {
        // user is previously logged and we have his data
        // we will let him access the app
      //  env.nav.push(HomePage);
      //  env.splashScreen.hide();
      //}, function (error) {
        //we don't have the user data so we will ask him to log in
        //this.navCtrl.push(LoginPage);
        env.statusBar.styleDefault();
        env.splashScreen.hide();

    });


  }
}
