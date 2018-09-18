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


    async getLocationAsync(lat: number, lng: number): Promise<any> {
         let url = apiUrl+'?latlng='+lat+','+lng+'&key='+apiKey;

         try {
            let response = await this.http.get(url).toPromise();
            return this.processData(response);
         } catch (error) {
             //await this.handleError(error);
             //return '';
         }
    }

    getLocation(lat: number, lng: number) {
     
        let url = apiUrl+'?latlng='+lat+','+lng+'&key='+apiKey;
        return new Promise(resolve => { this.http.get(url).toPromise()
            .then(
                res => {
                    console.log(res);
                    resolve(res);
                });
        });

      //return new Promise(resolve => { this.http.get(url).subscribe(data => { resolve(data); }, err => { console.log(err); }); });
    }

    //updateLocation(id: string, data): Observable<any> {
    //  const url = '${apiUrl}/${id}';
    //  return this.http.put(url, data, httpOptions)
    //    .pipe(
    //      catchError(this.handleError)
    //    );
    //}

    handleError(error: HttpErrorResponse) {
        if (error.error instanceof ErrorEvent) {
        console.error('An error occurred:', error.error.message);
        } else {
        console.error('Backend returned code ${error.status},' + 'body was: ${error.error}');
        }

        return throwError('Something bad happened; please try again later.');
    }

    processData(data: any) {

        if(data == undefined || data == null || data.results == undefined || data.results.length == 0)
            return { address:'', countryname:''};

        return {

            address : data.results[0].formatted_address,
            countryname : data.results[data.results.length-1].formatted_address
        };

        //data.results.forEach((res: any) => {

        //    result.address = res.formatted_address;
        //    result.countryname = res.formatted_address;
            //res.address_components.forEach((address: any) => {
       //       console.log(result);
            //});

       // });

      //  return result;
    }
  
}
