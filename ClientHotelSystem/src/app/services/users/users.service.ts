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

  getAllUsers(): Observable<User[]>{
    return this.http.get<User[]>(this.baseApiUrl + '/api/users');
  }

  addUser(addUserRequest: User): Observable<User>{
    return this.http.post<User>(this.baseApiUrl + '/api/users', addUserRequest);
  }

  getUser(id: string): Observable<User>{
    return this.http.get<User>(this.baseApiUrl + '/api/users/' + id);
  }

  updateUser(id: string, updateUserRequest: User): Observable<User>{
    return this.http.put<User>(this.baseApiUrl + '/api/users/' + id, updateUserRequest);
  }

  deleteUser(id: string): Observable<User>{
    return this.http.delete<User>(this.baseApiUrl + '/api/users/' + id);
  }

  loginUser(loginInfo: Array<string>){
    return this.http.post(this.baseApiUrl + '/api/users/LoginUser',{
      Email: loginInfo[0],
      Password: loginInfo[1]
    });
  }
}
