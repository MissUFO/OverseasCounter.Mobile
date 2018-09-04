import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss']
})
export class HomePage implements OnInit {

    constructor(private geolocation: Geolocation) 
    {
        this.subscribeGeoEvents();
    }

    ngOnInit() {
    }

    subscribeGeoEvents() {

        //this.geolocation.getCurrentPosition().then((resp) => {
        // console.log(resp.coords.latitude);
        // console.log(resp.coords.longitude);
        //}).catch((error) => {
        //  console.log('Error getting location', error);
        //});

        //let watch = this.geolocation.watchPosition();
        //watch.subscribe((data) => {
         // data can be a set of coordinates, or an error (if an error occurred).
        // console.log(data.coords.latitude);
        // console.log(data.coords.longitude);
        //});

    }
}
