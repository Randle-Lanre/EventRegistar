import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Registar } from './registar';
import { Participants } from './participants';
// import { OidcSecurityService} from 'angular-auth-oidc-client'


// const token = this.oidcSecurityService.getToken();


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',

  })
}

@Injectable({
  providedIn: 'root'
})
export class RegistarServiceService {
readonly apiUrl = 'https://localhost:6001/api/Registar';

registrationInfo: Registar
registrationResults: Registar[]


  constructor(private http: HttpClient ) { }




  addUserToRegistar( registar: Registar): Observable<Registar>{
    return this.http.post<Registar>(this.apiUrl, registar);
  }

//  getListOfParticipants ():Observable<Participants[]> {
//    return this.http.get<Participants[]>(this.apiUrl, httpOptions )
//  }

 getListOfParticipants () {
  return this.http.get(this.apiUrl ).toPromise().then(res => this.registrationResults = res as Registar[]);
}

// TODO: confirm if a type with ID needs to be returned, for now i am using a type of participant with ID
updateListOfParticipants(participant: Participants ){
  return this.http.put<Participants>(this.apiUrl, participant);
}


deleteAParticipant(id: number): Observable<{}>{
  const url = `${this.apiUrl}/${id}`;
  return this.http.delete(url, httpOptions);

}

//return this.http.put(`${this.apiurl}/${this.registrationinfo.id}`, this.registrationinfo)

}
