import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/users/registration.model';
import { UsersService } from 'src/app/services/users/users.service';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {

  userDetails: User = {
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
  };
  
  constructor(private route: ActivatedRoute, private userService: UsersService, private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if(id){
          this.userService.getUser(id)
          .subscribe({
            next: (response) => {
              this.userDetails = response;
            }
          });
        }
      }
    })
  }

  updateUser(){
    this.userService.updateUser(this.userDetails.id,
      this.userDetails)
      .subscribe({
        next: (response) => {
          this.router.navigate(['users']);
        }
      })
  }

  deleteUser(id: string){
    this.userService.deleteUser(id)
    .subscribe({
      next: (response) => {
        this.router.navigate(['users']);
      }
    })
  }

}
