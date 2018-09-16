import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class UserGeoLocation {
  latitude: number;
  longitude: number;
  countryname: string;
  timestamp: any;
}