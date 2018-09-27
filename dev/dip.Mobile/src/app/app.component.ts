import { Component } from '@angular/core';
import { Platform } from '@ionic/angular';

import { IonicNativePlugin } from '@ionic-native/core';

import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';

import { ActivatedRoute, Router } from '@angular/router';
import { Storage } from '@ionic/storage';
import { Geolocation } from '@ionic-native/geolocation/ngx';
import { BackgroundFetch, BackgroundFetchConfig } from '@ionic-native/background-fetch/ngx';
import { Facebook } from '@ionic-native/facebook/ngx';

import { User } from './_interfaces/user';
import { UserGeoLocation } from './_interfaces/usergeolocation';
import { UserAccount } from './_interfaces/useraccount';

import { UserService } from './_services/user.service';
import { GeoService } from './_services/geo.service';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html'
})
export class AppComponent {
  constructor(
    private platform: Platform,
    private splashScreen: SplashScreen,
    private statusBar: StatusBar,
    private router: Router,

    private storage: Storage,
    private geolocation: Geolocation,
    private backgroundFetch: BackgroundFetch,
    private facebook: Facebook,

    public userService: UserService, 
    public geoService: GeoService, 
  ) 
  {
    this.initializeApp();
  }

  
  initializeApp() {

    this.platform.ready().then(() => {

        this.statusBar.styleDefault();
        this.splashScreen.hide();

        this.startBackgroundProcess();

        this.router.navigate(['/login']);
    });

  }

  startBackgroundProcess()
  {
          const config: BackgroundFetchConfig = {
            stopOnTerminate: false, // Set true to cease background-fetch from operating after user "closes" the app. Defaults to true.
          };

          this.backgroundFetch.configure(config)
             .then(() => {
                 console.log('Background Fetch initialized');

                 this.backgroundFetch.finish();

             })
             .catch(e => console.log('Error initializing background fetch', e));

          // Start the background-fetch API. Your callbackFn provided to #configure will be executed each time a background-fetch event occurs. NOTE the #configure method automatically calls #start. You do not have to call this method after you #configure the plugin
          this.backgroundFetch.start();

          // Stop the background-fetch API from firing fetch events. Your callbackFn provided to #configure will no longer be executed.
          this.backgroundFetch.stop();

  }
}
