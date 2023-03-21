import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/users/registration.model';
import { UsersService } from 'src/app/services/users/users.service';

@Component({
  selector: 'app-get-user',
  templateUrl: './get-user.component.html',
  styleUrls: ['./get-user.component.css']
})
export class GetUserComponent implements OnInit {

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

  logOut(){
      this.userService.removeToken();
      this.router.navigate(['users/login']);
  }

}
