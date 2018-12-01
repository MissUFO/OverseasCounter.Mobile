import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';

import { UserService } from '../_services/user.service';
import { UserAccount } from '../_interfaces/useraccount';

import { SettingsService } from '../_services/settings.service';

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
      public settingsService: SettingsService, 
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
         this.checkOnboardingAndRedirect();
     }
  }

  onLogin(form: NgForm) {

      this.settingsService.get('CONTACT_EMAIL').then(itm=> 
      {
          console.log('test: ' + itm);
      });
    

    this.submitted = true;

    if (form.valid) {
      
      this.storage.set('userInfo', this.login);
  
      //this.userService.login(this.login.username);

      this.checkOnboardingAndRedirect();

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

            this.checkOnboardingAndRedirect();

        }else
        {
            this.showErrorToast();
        }
  }

  onGoogle() {
    this.checkOnboardingAndRedirect();
  }

  onTwitter() {
    this.checkOnboardingAndRedirect();
  }

  onSignup() {
    this.router.navigateByUrl('/login-registration');
  }

  onRestore() {
    this.router.navigateByUrl('/login-restore');
  }

  checkOnboardingAndRedirect()
  {
        this.storage.get('onboarded').then(res => {
          if (res!=null && res!=undefined && res) {
              this.router.navigateByUrl('/tabs/(home:home)');
          }else
          {
              this.router.navigateByUrl('/onboard');
          }
        });
  }
 
  async showErrorToast() {
    const toast = await this.toastController.create({
      message: "Пользователь не найден. Возможно, логин или пароль указаны не верно, или вы не зарегистрированы.",
      duration: 3000
    });
    toast.present();
  }

}