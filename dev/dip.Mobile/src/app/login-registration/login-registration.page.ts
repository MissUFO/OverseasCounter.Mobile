import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

import { UserService } from '../_services/user.service';
import { UserAccount } from '../_interfaces/useraccount';


@Component({
  selector: 'app-login-registration',
  templateUrl: './login-registration.page.html',
  styleUrls: ['./login-registration.page.scss'],
})
export class LoginRegistrationPage implements OnInit {

  signup: UserAccount = { username: '', password: '' };
  
  constructor(
    public router: Router,
    public userService: UserService
  ) {}

  onSignup(form: NgForm) {
    
    if (form.valid) {
      this.userService.signup(this.signup.username);
      this.router.navigateByUrl('/tabs/(home:home)');
    }
  }

  ngOnInit() {
  }

}
