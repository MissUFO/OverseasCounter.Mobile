import { Injectable } from '@angular/core';
import { UserAccount } from './useraccount';
import { UserGeoLocation } from './usergeolocation';

@Injectable({
  providedIn: 'root'
})

export class User {
    id: number;
    name: string;
    account: UserAccount = new UserAccount();
    picture: string = '../assets/img/user_picture.png';
    location: UserGeoLocation = new UserGeoLocation();
}