import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';
import { Events } from '@ionic/angular';
import { Storage } from '@ionic/storage';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};
const apiUrl = "https://maps.googleapis.com/maps/api/geocode/json";
const apiKey = "AIzaSyCziO9o5MpWPhM2PdZLQzePa0-Hwz7WR2I"

@Injectable({
  providedIn: 'root'
})

export class GeoService {

  constructor(
    public events: Events,
    public storage: Storage,
    private http: HttpClient
  ) { }

    getLocation(lat: number, lng: number): Observable<any> {
      debugger;

      let url = apiUrl+'?latlng='+lat+','+lng+'&key='+apiKey;
     

      return this.http.get(url, httpOptions);//.pipe(
          //map(this.processData, this)
          //,
          //catchError(this.handleError)
          //);
    }

    //updateLocation(id: string, data): Observable<any> {
    //  const url = '${apiUrl}/${id}';
    //  return this.http.put(url, data, httpOptions)
    //    .pipe(
    //      catchError(this.handleError)
    //    );
    //}

    private handleError(error: HttpErrorResponse) {
        if (error.error instanceof ErrorEvent) {
        console.error('An error occurred:', error.error.message);
        } else {
        console.error('Backend returned code ${error.status},' + 'body was: ${error.error}');
        }

        return throwError('Something bad happened; please try again later.');
    }

    private processData(data: any) {
        debugger;

        data.results.forEach((res: any) => {

            res.address_components.forEach((address: any) => {
              console.log(address.formatted_address);
            });

        });

        return data;
    }
  
}
