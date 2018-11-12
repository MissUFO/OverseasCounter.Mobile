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

import { Push, PushObject, PushOptions } from '@ionic-native/push/ngx';

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
    private push: Push
  ) 
  {
      this.initializeApp();
      this.initializePushNotification();
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

    initializePushNotification()
    {
        // to check if we have permission
        this.push.hasPermission()
        .then((res: any) => {

          if (res.isEnabled) {
            console.log('We have permission to send push notifications');
          } else {
            console.log('We do not have permission to send push notifications');
          }

        });

        // Create a channel (Android O and above). You'll need to provide the id, description and importance properties.
        this.push.createChannel({
            id: "overseascounter",
            description: "My first test channel",
            // The importance property goes from 1 = Lowest, 2 = Low, 3 = Normal, 4 = High and 5 = Highest.
            importance: 3
        }).then(() => console.log('Channel created'));

        // Delete a channel (Android O and above)
        //this.push.deleteChannel('testchannel1').then(() => console.log('Channel deleted'));

        // Return a list of currently configured channels
        //this.push.listChannels().then((channels) => console.log('List of channels', channels))

        // to initialize push notifications

        const options: PushOptions = {
         android: {},
         ios: {
             alert: 'true',
             badge: true,
             sound: 'false'
         },
         windows: {},
         browser: {
             pushServiceURL: 'http://push.api.phonegap.com/v1/push'
         }
        };

        const pushObject: PushObject = this.push.init(options);

        pushObject.on('notification').subscribe((notification: any) => console.log('Received a notification', notification));

        pushObject.on('registration').subscribe((registration: any) => console.log('Device registered', registration));

        pushObject.on('error').subscribe(error => console.error('Error with Push plugin', error));
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
