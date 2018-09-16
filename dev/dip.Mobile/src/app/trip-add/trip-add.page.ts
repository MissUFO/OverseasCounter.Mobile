import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { Storage } from '@ionic/storage';

@Component({
  selector: 'app-trip-add',
  templateUrl: './trip-add.page.html',
  styleUrls: ['./trip-add.page.scss'],
})
export class TripAddPage implements OnInit {

  //login: UserAccount = { username: '', password: '' };

  constructor(public router: Router,
    private storage: Storage,
    public toastController: ToastController) { }

  ngOnInit() {
  }

  onSave(form: NgForm) {

    if (form.valid) {

     //   console.log('User name:', this.login.username);
     //   console.log('Password:', this.login.username);

      //this.userService.login(this.login.username);

      this.router.navigateByUrl('/tabs/(home:home)');

    }else
    {
        this.showErrorToast();
    }
  }

  onCancel() {
   this.router.navigateByUrl('/tabs/(home:home)');
  }

   async showErrorToast() {
    const toast = await this.toastController.create({
      message: "Не удалось сохранить изменения. Возможно, у вас отсутствует связь.",
      duration: 2000
    });
    toast.present();
  }

}
