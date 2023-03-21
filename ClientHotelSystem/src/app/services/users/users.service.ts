import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from 'src/app/models/users/registration.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  currentUser : BehaviorSubject<any> = new BehaviorSubject(null);
  baseApiUrl: string = environment.baseApiUrl;
  isLogin: boolean = false;
  jwtHelperService = new JwtHelperService();

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

  getUserMail(mail: string): Observable<User>{
    return this.http.get<User>(this.baseApiUrl + '/api/users/' + mail);
  }

  updateUserMail(mail: string, updateUserRequestMail: User): Observable<User>{
    return this.http.put<User>(this.baseApiUrl + '/api/users/' + mail, updateUserRequestMail);
  }

  deleteUserMail(mail: string): Observable<User>{
    return this.http.delete<User>(this.baseApiUrl + '/api/users/' + mail);
  }

  loginUser(loginInfo: Array<string>){
    return this.http.post(this.baseApiUrl + '/api/users/LoginUser',
      {
        Email: loginInfo[0],
        Password: loginInfo[1],
      },
      {
        responseType: 'text',
      }
    );
  }

  setToken(token: string){
    localStorage.setItem("access_token", token);
    this.loadCurrentUser();
  }

  loadCurrentUser(){
    const token = localStorage.getItem("access_token");
    const userInfo = token != null ? this.jwtHelperService.decodeToken(token) : null;
    const data = userInfo ? {
      id: userInfo.id,
      firstname: userInfo.firstname,
      lastname: userInfo.lastname,
      email: userInfo.email,
      phonenumber: userInfo.phonenumber
    } : null;
    this.currentUser.next(data);
  }

  isLoggedin(): boolean{
    return localStorage.getItem("access_token") ? true : false;
  }

  removeToken(){
    localStorage.removeItem("access_token");
  }
}
