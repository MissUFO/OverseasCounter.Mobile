import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';
import { Events } from '@ionic/angular';
import { Storage } from '@ionic/storage';

//global constants
import { GlobalService } from '../global.service';

//interfaces
import { Setting } from '../_interfaces/setting';
import { debug } from 'util';

const httpOptions =  new HttpHeaders({ 'Content-Type': 'application/json' });
const serviceApiUrl = "/settings";

@Injectable({
  providedIn: 'root'
})
export class SettingsService {

    constructor(
        private http: HttpClient, 
        public storage: Storage,
        public global: GlobalService) { }

    getList() : Promise<Setting>
    {
        try {

            return new Promise(resolve => {
                this.http.get<Setting>(this.global.webApiUrl + serviceApiUrl+'/list').subscribe(data => {

                    resolve(data);

                    this.storage.set("settings", data);

                }, err => {
                  console.log(err);
                });
            });

        } catch (error) {
            console.log(error);

            return null;
        }
    }

    get(setting_key : string)
    {       
        return this.storage.get("settings").then(itms => 
        {
            let result = '';
        
            for(let i = 0; i < itms.length; i++) 
            {
                if(itms[i].Key == setting_key)
                {
                    result = itms[i].Value;
                    break;
                }
            }
            return result;
        });
    }
}
