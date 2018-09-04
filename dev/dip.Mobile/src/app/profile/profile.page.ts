import { Component, OnInit } from '@angular/core';
import { Facebook } from '@ionic-native/facebook';
import { NativeStorage } from '@ionic-native/native-storage';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.page.html',
  styleUrls: ['./profile.page.scss'],
})
export class ProfilePage implements OnInit {

    user: any;
    userReady: boolean = false;

  constructor(
        public fb: Facebook,
        public nativeStorage: NativeStorage
    ) {}

    ionViewCanEnter(){
        let env = this;
        this.nativeStorage.getItem('user')
        .then(function (data){
            env.user = {
                name: data.name,
                gender: data.gender,
                picture: data.picture
            };
                env.userReady = true;
        }, function(error){
            console.log(error);
        });
    }

    doFbLogout(){
        //var nav = this.navCtrl;
        let env = this;
        this.fb.logout()
        .then(function(response) {
            //user logged out so we will remove him from the NativeStorage
            env.nativeStorage.remove('user');
           // nav.push(LoginPage);
        }, function(error){
            console.log(error);
        });
    }

  ngOnInit() {
  }

}
