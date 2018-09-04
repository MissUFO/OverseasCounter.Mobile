import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';

import { IonicModule } from '@ionic/angular';

import { CountryVisaAddPage } from './country-visa-add.page';

const routes: Routes = [
  {
    path: '',
    component: CountryVisaAddPage
  }
];

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    RouterModule.forChild(routes)
  ],
  declarations: [CountryVisaAddPage]
})
export class CountryVisaAddPageModule {}
