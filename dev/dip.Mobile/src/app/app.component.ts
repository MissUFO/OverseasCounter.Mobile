import { Component } from '@angular/core';
import { Platform } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';

import { ActivatedRoute, Router } from '@angular/router';
import { Storage } from '@ionic/storage';
//import { BackgroundFetch, BackgroundFetchConfig } from '@ionic-native/background-fetch';

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
    private storage: Storage//,
 //   private backgroundFetch: BackgroundFetch
  ) 
  {
    this.initializeApp();
  }


  initializeApp() {

    this.platform.ready().then(() => {

        this.statusBar.styleDefault();
        this.splashScreen.hide();

        //this.startBackgroundProcess();

        this.router.navigate(['/login']);
    });


  }

  startBackgroundProcess()
  {
        //const config: BackgroundFetchConfig = {
        //        stopOnTerminate: false, // Set true to cease background-fetch from operating after user "closes" the app. Defaults to true.
                //startOnBoot: true,
                //minimumFetchInterval: 240, // <-- every 4 hours, default is 15 min

        //};
        //this.backgroundFetch.configure(config)
       //     .then(() => {
             console.log('Background Fetch initialized');

       //      this.backgroundFetch.finish();
       //     })
       //     .catch(e => console.log('Error initializing background fetch', e));

        // Start the background-fetch API. Your callbackFn provided to #configure will be executed each time a background-fetch event occurs
        //this.backgroundFetch.start();

        // Stop the background-fetch API from firing fetch events. Your callbackFn provided to #configure will no longer be executed.
        //this.backgroundFetch.stop();
  }
}
