import { Component } from '@angular/core';
import { LoadingController, Platform } from '@ionic/angular';
import { FormControl, FormGroupDirective, FormBuilder, FormGroup, NgForm, Validators, FormArray } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { IonicNativePlugin } from '@ionic-native/core';

import { Geolocation } from '@ionic-native/geolocation/ngx';
import { Storage } from '@ionic/storage';

import { User } from '../_interfaces/user';
import { UserGeoLocation } from '../_interfaces/usergeolocation';
import { UserAccount } from '../_interfaces/useraccount';

import { UserService } from '../_services/user.service';
import { GeoService } from '../_services/geo.service';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss']
})
export class HomePage {

    user: User;

    trace: any;

    constructor(
        private platform: Platform,
        private geolocation: Geolocation,
        private storage: Storage,

        public userService: UserService, 
        public geoService: GeoService, 

        public loadingController: LoadingController,
        public route: ActivatedRoute,
        public router: Router) 
    {
        this.user = new User();

        this.subscribeGeoEvents();
    }

    async subscribeGeoEvents() {
        await this.refreshGeoLocation();
    }

    async refreshGeoLocation()
    {
        console.log('Getting current location...');

        this.user.name = 'Татьяна Сметанина';

        this.geolocation.getCurrentPosition().then((resp) => {

            this.user.location.latitude = resp.coords.latitude;
            this.user.location.longitude = resp.coords.longitude;
            this.user.location.timestamp = resp.timestamp;

        }).catch((error) => {
            console.log('Error getting location', error);
        }).then( resp => this.setCurrentCountry(this.user.location) );

        this.getDebugInfo();
    }

    async setCurrentCountry(location: any)
    {
        let result = await this.geoService.getLocationAsync(location.latitude, location.longitude);

        this.user.location.countryname = result.countryname;
        this.user.location.address = result.address;

        return this.user.location;
    }

    goProfile()
    {
        this.router.navigateByUrl('/tabs/(profile:profile)');
    }

    getDebugInfo()
    {
        this.storage.get('debugInfo').then((val) => {
            this.trace = val;
        });
    }

}
