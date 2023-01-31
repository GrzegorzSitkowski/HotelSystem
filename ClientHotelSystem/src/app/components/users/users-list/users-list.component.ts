import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/users/list-users.model';
import { UsersService } from 'src/app/services/users/users.service';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.css']
})
export class UsersListComponent implements OnInit {

  users: User[] = [];
  constructor(private userService: UsersService) { }

  ngOnInit(): void {
    this.userService.getAllUsers()
    .subscribe({
      next: (users) => {
        this.users = users as User[];
        console.log(this.users);
      },
      error: (response) => {
        console.log(response);
      }
    })
  }

}
