import { Component, OnInit } from '@angular/core';
import { UsersService } from './services/users/users.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  isLogin: boolean = false;
  constructor(private userService: UsersService){}ngOnInit(): void {
    this.isLogin = this.userService.isLogin;
  }
;
  title = 'ClientHotelSystem';
}
