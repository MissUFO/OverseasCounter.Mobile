import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

import { UserService } from '../_services/user.service';
import { UserAccount } from '../_interfaces/useraccount';



@Component({
  selector: 'app-login-restore',
  templateUrl: './login-restore.page.html',
  styleUrls: ['./login-restore.page.scss'],
})
export class LoginRestorePage implements OnInit {

  restore: UserAccount = { username: '', password: '' };

  constructor(
    public router: Router,
    public userService: UserService
  ) {}

  onRestore(form: NgForm) {
   
    if (form.valid) {
      this.userService.signup(this.restore.username);
      this.router.navigateByUrl('/tabs/(home:home)');
    }
  }

  ngOnInit() {
  }

}
