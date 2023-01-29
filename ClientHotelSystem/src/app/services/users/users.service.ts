import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/app/models/users/registration.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http: HttpClient) { }

  addUser(addUserRequest: User): Observable<User>{
    return this.http.post<User>(this.baseApiUrl + '/api/users', addUserRequest);
  }
}
