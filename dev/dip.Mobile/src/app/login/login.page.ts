import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';

import { UserService } from '../_services/user.service';
import { UserAccount } from '../_interfaces/useraccount';


//import { Facebook } from '@ionic-native/facebook';
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
    public toastController: ToastController
  ) { 

        this.storage.set('name', 'Max');

        this.storage.get('name').then((val) => {
            console.log('Your age is', val);
        });

  }

  onLogin(form: NgForm) {
    this.submitted = true;

    if (form.valid) {

        console.log('User name:', this.login.username);
        console.log('Password:', this.login.username);

      //this.userService.login(this.login.username);

      this.router.navigateByUrl('/tabs/(home:home)');

    }else
    {
        this.showErrorToast();
    }
  }

  onFacebook() {
   this.router.navigateByUrl('/tabs/(home:home)');
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

//export class LoginPage implements OnInit {

//  FB_APP_ID: number = 1137665606387537;

//  constructor(
    //public fb: Facebook,
    //public nativeStorage: NativeStorage
//    ) 
//  {
    //this.fb.browserInit(this.FB_APP_ID, "v2.8");
//  }

//  ngOnInit() {
//  }

//  doFbLogin(){
    //let permissions = new Array<string>();
    //let nav = this.navCtrl;
    //let env = this;
    //the permissions your facebook app needs from the user
    //permissions = ["public_profile"];


    //this.fb.login(permissions)
    //.then(function(response){
    //  let userId = response.authResponse.userID;
    //  let params = new Array<string>();

      //Getting name and gender properties
    //  env.fb.api("/me?fields=name,gender", params).then(function(user) { console.log(user.name); });
    //  });
//  }
//}
        //user.picture = "https://graph.facebook.com/" + userId + "/picture?type=large";
        //now we have the users info, let's save it in the NativeStorage
        //env.nativeStorage.setItem('user',
        //{
        //  name: user.name,
        //  gender: user.gender,
        //  picture: user.picture
        //}
        //}).then(
        //        function(){
        //            console.log('success');
        //            nav.push(HomePage);
        //        },
        //        function (error) {
        //          console.log(error);
        //        }
        //)
        //  })
    // }, function(error){
    //   console.log(error);
    //  });
 