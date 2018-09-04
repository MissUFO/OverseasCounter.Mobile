import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';

import { IonicModule } from '@ionic/angular';

import { CountryVisaListPage } from './country-visa-list.page';

const routes: Routes = [
  {
    path: '',
    component: CountryVisaListPage
  }
];

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    RouterModule.forChild(routes)
  ],
  declarations: [CountryVisaListPage]
})
export class CountryVisaListPageModule {}
