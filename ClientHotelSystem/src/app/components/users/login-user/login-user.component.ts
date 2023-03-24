import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UsersService } from 'src/app/services/users/users.service';

@Component({
  selector: 'app-login-user',
  templateUrl: './login-user.component.html',
  styleUrls: ['./login-user.component.css']
})
export class LoginUserComponent implements OnInit {

  constructor(private userService: UsersService,private router: Router) { }

  ngOnInit(): void {
  }

  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.minLength(5), Validators.maxLength(20)]),
  });

  isUserValid: boolean = false;

  loginSubmited(){  
    this.userService.loginUser([this.loginForm.value.email!, this.loginForm.value.password!])
    .subscribe(res => {
      if(res == "Failure"){
        this.isUserValid = false;
        alert('Login unsuccesfull');
      }else{
        this.isUserValid = true;
        this.userService.setToken(res);
        this.router.navigate(['users/get/' + this.loginForm.value.email]);
        localStorage.setItem('mail', this.loginForm.value.email!);
        console.log(this.userService.isLogin);
      }
    });
  }

  get Email(): FormControl{
    return this.loginForm.get('email') as FormControl;
  }

  get Password(): FormControl{
    return this.loginForm.get('password') as FormControl;
  }
}