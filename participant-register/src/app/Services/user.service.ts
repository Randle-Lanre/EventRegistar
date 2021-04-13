import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';

import {User } from './user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  //TODO: refactor api 
  readonly apiUrl = 'https://localhost:6001/api/Registar';
  constructor(private http: HttpClient) { }


  getAll(){
    return this.http.get<User>(`${this.apiUrl}/users`);
  }
}
