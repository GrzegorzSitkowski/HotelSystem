import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/users/registration.model';
import { UsersService } from 'src/app/services/users/users.service';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user-by-mail.component.html',
  styleUrls: ['./edit-user-by-mail.component.css']
})
export class EditUserByMailComponent implements OnInit {

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
        const mail = params.get('mail');

        if(mail){
          this.userService.getUserMail(mail)
          .subscribe({
            next: (response) => {
              this.userDetails = response;
            }
          });
        }
      }
    })
  }

  updateUserMail(){
    this.userService.updateUserMail(this.userDetails.mail,
      this.userDetails)
      .subscribe({
        next: (response) => {
          this.router.navigate(['users']);
        }
      })
  }

  deleteUserMail(mail: string){
    this.userService.deleteUserMail(mail)
    .subscribe({
      next: (response) => {
        this.router.navigate(['users']);
      }
    })
  }

}
