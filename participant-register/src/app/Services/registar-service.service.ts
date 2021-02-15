import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Registar } from './registar';


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class RegistarServiceService {
apiUrl = 'api/events'


  constructor(private http: HttpClient) { }



  addUserToRegistar( registar: Registar): Observable<Registar>{
    return this.http.post<Registar>(this.apiUrl, registar, httpOptions);
  }
}
