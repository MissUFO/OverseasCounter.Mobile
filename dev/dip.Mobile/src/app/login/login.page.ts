import { Component, OnInit } from '@angular/core';
import { Facebook } from '@ionic-native/facebook';
import { NativeStorage } from '@ionic-native/native-storage';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})

export class LoginPage implements OnInit {

  FB_APP_ID: number = 1137665606387537;

  constructor(
    public fb: Facebook,
    public nativeStorage: NativeStorage
    ) 
  {
    //this.fb.browserInit(this.FB_APP_ID, "v2.8");
  }

  ngOnInit() {
  }

  doFbLogin(){
    let permissions = new Array<string>();
    //let nav = this.navCtrl;
    let env = this;
    //the permissions your facebook app needs from the user
    permissions = ["public_profile"];


    this.fb.login(permissions)
    .then(function(response){
      let userId = response.authResponse.userID;
      let params = new Array<string>();

      //Getting name and gender properties
      env.fb.api("/me?fields=name,gender", params).then(function(user) { console.log(user.name); });
      });
  }
}
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
 