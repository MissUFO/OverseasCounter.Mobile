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

  location : UserGeoLocation;
  
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

      //stop background-fetch process (if it was started)
      this.backgroundFetch.stop();

          const config: BackgroundFetchConfig = {
            stopOnTerminate: false, // Set true to cease background-fetch from operating after user "closes" the app. Defaults to true.
          };

          this.backgroundFetch.configure(config)
              .then(() => {

                 this.saveDebugInfo('Background Fetch initialized');

                 this.saveDebugInfo('Getting current location...');

                 this.geolocation.getCurrentPosition().then((resp) => {

                     if(resp!=null && resp!=undefined)
                         {
                            this.location.latitude = resp.coords.latitude;
                            this.location.longitude = resp.coords.longitude;
                            this.location.timestamp = resp.timestamp;

                            this.saveDebugInfo(this.location.latitude + ', ' + this.location.longitude);
                     }else
                     {
                         this.saveDebugInfo('Responce was undefined');
                     }

                 }).catch((error) => {

                     this.saveDebugInfo('Error getting location. ' + error);

                 }).then( resp => {

                     this.setCurrentCountry(this.location); 
                     this.saveDebugInfo(this.location.countryname + ' ' + this.location.address);

                } );

                 this.backgroundFetch.finish();

             })
             .catch(e => this.saveDebugInfo('Error initializing background fetch' + e));

          // Start the background-fetch API. Your callbackFn provided to #configure will be executed each time a background-fetch event occurs. NOTE the #configure method automatically calls #start. You do not have to call this method after you #configure the plugin
          this.backgroundFetch.start();

          // Stop the background-fetch API from firing fetch events. Your callbackFn provided to #configure will no longer be executed.
          //this.backgroundFetch.stop();

  }

    saveDebugInfo(trace)
    {
        let debugInfo = '';

        this.storage.get('debugInfo').then((val) => {
            if(val!=null){
                debugInfo = val;
            }
            debugInfo += '[' + new Date().toLocaleString() + ']';
            debugInfo += ': '+ trace + '\r\n';
            this.storage.set('debugInfo', debugInfo);
        });

    }


    async setCurrentCountry(location: any)
    {
        let result = await this.geoService.getLocationAsync(location.latitude, location.longitude);

        this.location.countryname = result.countryname;
        this.location.address = result.address;

        return this.location;
    }
}
