import { Injectable } from '@angular/core';
import { UserAccount } from './useraccount';
import { UserGeoLocation } from './usergeolocation';

@Injectable({
  providedIn: 'root'
})

export class User {
    id: number;
    name: string;
    account: UserAccount;
    picture: string;
    location: UserGeoLocation;
}