import { Component, OnInit } from '@angular/core';
import { UsersService } from './services/users/users.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  isLogin: boolean = false;
  urlAfterLogin = 'users/get/'
  constructor(private userService: UsersService){}
  
  
    ngOnInit(): void {
    this.isLogin = this.userService.isLogin;
      if(localStorage.getItem("access_token") == null){
        this.isLogin = false;
      }else{
        this.isLogin = true;
      }
      this.urlAfterLogin += localStorage.getItem("mail");
  } 
}
