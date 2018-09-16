import { Component, OnInit } from '@angular/core';
import { LoadingController } from '@ionic/angular';
import { FormControl, FormGroupDirective, FormBuilder, FormGroup, NgForm, Validators, FormArray } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { UserService } from '../_services/user.service';
import { User } from '../_interfaces/user';

import { GeoService } from '../_services/geo.service';
import { UserGeoLocation } from '../_interfaces/usergeolocation';

import { Geolocation } from '@ionic-native/geolocation/ngx';
import { Storage } from '@ionic/storage';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss']
})
export class HomePage implements OnInit {

    constructor(
    private geolocation: Geolocation, 
    private storage: Storage,
    public userService: UserService, 
    public geoService: GeoService, 
    public loadingController: LoadingController,
    public route: ActivatedRoute,
    public router: Router) 
    {
       
    }

    user: any;
    location: any;

    ngOnInit() {

     this.subscribeGeoEvents();

    }

    subscribeGeoEvents() {

    this.user = {
            name: "Татьяна Сметанина",
            currentCountryName: "Россия",
            picture: "https://www.gravatar.com/avatar?d=mm&s=140"
    };

    this.refreshGeoLocation();
      
    }

    refreshGeoLocation()
    {
        console.log('Getting current location...');

        this.geolocation.getCurrentPosition().then((resp) => {

            this.location = ('Latitude: '          + resp.coords.latitude          + '\n' +
              'Longitude: '         + resp.coords.longitude         + '\n' +
              'Altitude: '          + resp.coords.altitude          + '\n' +
              'Accuracy: '          + resp.coords.accuracy          + '\n' +
              'Altitude Accuracy: ' + resp.coords.altitudeAccuracy  + '\n' +
              'Heading: '           + resp.coords.heading           + '\n' +
              'Speed: '             + resp.coords.speed             + '\n' +
              'Timestamp: '         + resp.timestamp                + '\n');

            this.user.currentCountryName = this.geoService.getLocation(resp.coords.latitude, resp.coords.longitude);
            console.log(this.user.currentCountryName);

        }).catch((error) => {
            console.log('Error getting location', error);
        });

       
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

//    async getClassrooms() {
//          const loading = await this.loadingController.create({
//            content: 'Loading'
//          });
//          await loading.present();
//          await this.api.getClassroom()
//            .subscribe(res => {
//              console.log(res);
//              this.classrooms = res;
//              loading.dismiss();
//            }, err => {
//              console.log(err);
//              loading.dismiss();
//            });
//    }
}
