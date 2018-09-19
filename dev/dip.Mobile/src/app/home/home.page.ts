import { Component, OnInit } from '@angular/core';
import { LoadingController } from '@ionic/angular';
import { FormControl, FormGroupDirective, FormBuilder, FormGroup, NgForm, Validators, FormArray } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { UserService } from '../_services/user.service';
import { User } from '../_interfaces/user';

import { GeoService } from '../_services/geo.service';

import { Geolocation } from '@ionic-native/geolocation/ngx';
import { Storage } from '@ionic/storage';
import { UserGeoLocation } from '../_interfaces/usergeolocation';
import { UserAccount } from '../_interfaces/useraccount';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss']
})
export class HomePage implements OnInit {

    user: User;

    constructor(
    private geolocation: Geolocation, 
    private storage: Storage,
    public userService: UserService, 
    public geoService: GeoService, 
    public loadingController: LoadingController,
    public route: ActivatedRoute,
    public router: Router) 
    {
        this.user = new User();
        //this.user.location = new UserGeoLocation();
        //this.user.account = new UserAccount();

        this.subscribeGeoEvents();
    }

    ngOnInit() {

    }

    async subscribeGeoEvents() {
        await this.refreshGeoLocation();
    }

    async refreshGeoLocation()
    {
        console.log('Getting current location...');

        this.user.name = 'Татьяна Сметанина';
        //this.user.picture = '../assets/img/user_picture.png';

        this.geolocation.getCurrentPosition().then((resp) => {

            this.user.location.latitude = resp.coords.latitude;
            this.user.location.longitude = resp.coords.longitude;
            this.user.location.timestamp = resp.timestamp;

        }).catch((error) => {
            console.log('Error getting location', error);
        }).then( resp => this.setCurrentCountry(this.user.location) );

    }

    async setCurrentCountry(location: any)
    {
        let result = await this.geoService.getLocationAsync(location.latitude, location.longitude);

        this.user.location.countryname = result.countryname;
        this.user.location.address = result.address;

        return this.user.location;
    }

    watchGeoLocation()
    {
        let watch = this.geolocation.watchPosition();
        watch.subscribe((data) => {
            // data can be a set of coordinates, or an error (if an error occurred).
            // data.coords.latitude
            // data.coords.longitude
        });
    }

    goProfile()
    {
        this.router.navigateByUrl('/tabs/(profile:profile)');
    }

}
