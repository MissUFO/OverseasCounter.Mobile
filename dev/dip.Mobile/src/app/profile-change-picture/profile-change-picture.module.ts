import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';

import { IonicModule } from '@ionic/angular';

import { ProfileChangePicturePage } from './profile-change-picture.page';

const routes: Routes = [
  {
    path: '',
    component: ProfileChangePicturePage
  }
];

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    RouterModule.forChild(routes)
  ],
  declarations: [ProfileChangePicturePage]
})
export class ProfileChangePicturePageModule {}
