import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class UserAccount {
  username: string;
  password: string;
}