import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class UserGeoLocation {
    latitude: number;
    longitude: number;
    countryname: string;
    address: string;
    timestamp: any;

    constructor(latitude: number = null, longitude: number = null, countryname: string = '', address: string = '', timestamp: any = null) {
        this.latitude = latitude;
        this.longitude = longitude;
        this.countryname = countryname;
        this.address = address;
        this.timestamp = timestamp;
    }
}