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
        this.runBackgroundTask();

        this.router.navigate(['/login']);
    });

  }

  async startBackgroundProcess()
  {

      //stop background-fetch process (if it was started)
      //this.backgroundFetch.stop();
      await this.saveDebugInfo('Background Fetch status:' + await this.backgroundFetch.status() );

      const config: BackgroundFetchConfig = {
              stopOnTerminate: false, // Set true to cease background-fetch from operating after user "closes" the app. Defaults to true.
      };

      this.backgroundFetch.configure(config).then(() => {

         this.runBackgroundTask();
         this.backgroundFetch.finish();

      })
      .catch(e => this.saveDebugInfo('Error initializing background fetch' + e));

      // Start the background-fetch API. Your callbackFn provided to #configure will be executed each time a background-fetch event occurs. NOTE the #configure method automatically calls #start. You do not have to call this method after you #configure the plugin
      this.backgroundFetch.start();

      await this.saveDebugInfo('Background Fetch status:' + await this.backgroundFetch.status() );

      // Stop the background-fetch API from firing fetch events. Your callbackFn provided to #configure will no longer be executed.
      //this.backgroundFetch.stop();
  }

  runBackgroundTask()
  {
      this.saveDebugInfo('Background Fetch initialized');

      try
      {
         this.geolocation.getCurrentPosition().then((resp) => {

             this.saveDebugInfo('Getting current location...');
             let location = new UserGeoLocation();

             if(resp!=null && resp!=undefined)
             {
                 this.saveDebugInfo('response not null');

                 location.latitude = resp.coords.latitude;
                 location.longitude = resp.coords.longitude;
                 location.timestamp = resp.timestamp;

                 this.saveDebugInfo('coordinates: ' + resp.coords.latitude + ', ' + resp.coords.longitude);

                 this.setCurrentCountry(location).then((result) => {

                     location = result;
                     this.saveDebugInfo('country: ' + location.countryname + ' ' + location.address);
                 });

             }else
             {
                 this.saveDebugInfo('Responce was undefined');
             }

         }).catch((error) => {

             this.saveDebugInfo('Error getting location. ' + error);

         });

      }catch(e)
      {
          console.log(e);
      }
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


  setCurrentCountry(location: UserGeoLocation)
  {
      this.saveDebugInfo('trying to set country');

      return this.geoService.getLocationAsync(location.latitude, location.longitude).then((result) => {

          location.countryname = result.countryname;
          location.address = result.address;

          return location;
      });
  }
}
