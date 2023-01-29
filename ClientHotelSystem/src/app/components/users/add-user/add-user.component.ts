import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/users/registration.model';
import { UsersService } from 'src/app/services/users/users.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

  addUserRequest: User = {
    id: '0',
    firstName: '',
    lastName: '',
    type: '',
    mail: '',
    password: '',
    phoneNumner: '',
    address: '',
    postCode: '',
    city: ''
  }

  constructor(private userService: UsersService, private router: Router) { }

  ngOnInit(): void {
  }

  addUser(){
    console.log(this.addUserRequest);
    this.userService.addUser(this.addUserRequest)
    .subscribe({
      next: (user) => {
        this.router.navigate(['']);
      }
    })
  }

}
