import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';

import { IonicModule } from '@ionic/angular';

import { ProfileChangeUsernamePage } from './profile-change-username.page';

const routes: Routes = [
  {
    path: '',
    component: ProfileChangeUsernamePage
  }
];

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    RouterModule.forChild(routes)
  ],
  declarations: [ProfileChangeUsernamePage]
})
export class ProfileChangeUsernamePageModule {}
