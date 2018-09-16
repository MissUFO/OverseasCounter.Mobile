import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';
import { Events } from '@ionic/angular';
import { Storage } from '@ionic/storage';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};
const apiUrl = "http://localhost:1337/localhost:3000/api/classroom";

@Injectable({
  providedIn: 'root'
})

export class UserService {
  _favorites: string[] = [];
  HAS_LOGGED_IN = 'hasLoggedIn';
  HAS_SEEN_TUTORIAL = 'hasSeenTutorial';

  constructor(
    public events: Events,
    public storage: Storage,
    private http: HttpClient
  ) { }

  hasFavorite(sessionName: string): boolean {
    return (this._favorites.indexOf(sessionName) > -1);
  }

  addFavorite(sessionName: string): void {
    this._favorites.push(sessionName);
  }

  removeFavorite(sessionName: string): void {
    const index = this._favorites.indexOf(sessionName);
    if (index > -1) {
      this._favorites.splice(index, 1);
    }
  }

  login(username: string): Promise<any> {
    return this.storage.set(this.HAS_LOGGED_IN, true).then(() => {
      this.setUsername(username);
      return this.events.publish('user:login');
    });
  }

  signup(username: string): Promise<any> {
    return this.storage.set(this.HAS_LOGGED_IN, true).then(() => {
      this.setUsername(username);
      return this.events.publish('user:signup');
    });
  }

  logout(): Promise<any> {
    return this.storage.remove(this.HAS_LOGGED_IN).then(() => {
      return this.storage.remove('username');
    }).then(() => {
      this.events.publish('user:logout');
    });
  }

  setUsername(username: string): Promise<any> {
    return this.storage.set('username', username);
  }

  getUsername(): Promise<string> {
    return this.storage.get('username').then((value) => {
      return value;
    });
  }

  isLoggedIn(): Promise<boolean> {
    return this.storage.get(this.HAS_LOGGED_IN).then((value) => {
      return value === true;
    });
  }

  checkHasSeenTutorial(): Promise<string> {
    return this.storage.get(this.HAS_SEEN_TUTORIAL).then((value) => {
      return value;
    });
  }

    

    private handleError(error: HttpErrorResponse) {
        if (error.error instanceof ErrorEvent) {
        console.error('An error occurred:', error.error.message);
        } else {
        console.error('Backend returned code ${error.status},' + 'body was: ${error.error}');
        }

        return throwError('Something bad happened; please try again later.');
    }

    private extractData(res: Response) {
          let body = res;
          return body || { };
    }

    getClassroom(): Observable<any> {
      return this.http.get(apiUrl, httpOptions).pipe(
        map(this.extractData),
        catchError(this.handleError));
    }

    getClassroomById(id: string): Observable<any> {
      const url = '${apiUrl}/${id}';
      return this.http.get(url, httpOptions).pipe(
        map(this.extractData),
        catchError(this.handleError));
    }

    postClassroom(data): Observable<any> {
      const url = '${apiUrl}/add_with_students';
      return this.http.post(url, data, httpOptions)
        .pipe(
          catchError(this.handleError)
        );
    }

    updateClassroom(id: string, data): Observable<any> {
      const url = '${apiUrl}/${id}';
      return this.http.put(url, data, httpOptions)
        .pipe(
          catchError(this.handleError)
        );
    }

    deleteClassroom(id: string): Observable<{}> {
      const url = '${apiUrl}/${id}';
      return this.http.delete(url, httpOptions)
        .pipe(
          catchError(this.handleError)
        );

    }

}
