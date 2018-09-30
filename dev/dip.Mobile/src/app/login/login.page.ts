import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';

import { UserService } from '../_services/user.service';
import { UserAccount } from '../_interfaces/useraccount';

import { Facebook, FacebookLoginResponse } from '@ionic-native/facebook/ngx';
import { Storage } from '@ionic/storage';


@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})

export class LoginPage {

  login: UserAccount = { username: '', password: '' };
  submitted = false;

  constructor(
    public userService: UserService,
    public router: Router,
    private storage: Storage,
    public toastController: ToastController,
    private fb: Facebook
    ) 
  { 

     let authorized = false;

     this.storage.get('userInfo').then((val) => {
         if(val != null && val.username!=''){
             authorized = true;
         }
     });  

     if(authorized)
     {
         this.router.navigateByUrl('/tabs/(home:home)');
     }
  }

    onLogin(form: NgForm) {

    this.submitted = true;

    if (form.valid) {

      console.log('User name:', this.login.username);
      console.log('Password:', this.login.password);

      this.storage.set('userInfo', this.login);
  
      //this.userService.login(this.login.username);

      this.router.navigateByUrl('/tabs/(home:home)');

    }else
    {
        this.showErrorToast();
    }
  }

  onFacebook() {

        let result : FacebookLoginResponse = null;

        this.fb.login(['public_profile', 'user_friends', 'email'])
          .then((res: FacebookLoginResponse) => {result = res; console.log('Logged into Facebook!', res);})
            .catch(e => console.log('Error logging into Facebook', e));

        if(result != null)
        {
            console.log(result.status)
            console.log(result.authResponse.userID);

            this.router.navigateByUrl('/tabs/(home:home)');
        }else
        {
            this.showErrorToast();
        }
  }

  onGoogle() {
    this.router.navigateByUrl('/tabs/(home:home)');
  }

  onTwitter() {
    this.router.navigateByUrl('/tabs/(home:home)');
  }

  onSignup() {
    this.router.navigateByUrl('/login-registration');
  }
 
  async showErrorToast() {
    const toast = await this.toastController.create({
      message: "Не удалось авторизоваться. Пользователь не найден.",
      duration: 2000
    });
    toast.present();
  }

}