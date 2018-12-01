import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GlobalService {

    //global constants

    constructor() { }

    public webApiUrl = "https://daysinplace.azurewebsites.net/api";

}
