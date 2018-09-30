import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', loadChildren: './tabs/tabs.module#TabsPageModule' },
  { path: 'home', loadChildren: './home/home.module#HomePageModule' },
  { path: 'login', loadChildren: './login/login.module#LoginPageModule' },
  { path: 'login-registration', loadChildren: './login-registration/login-registration.module#LoginRegistrationPageModule' },
  { path: 'login-restore', loadChildren: './login-restore/login-restore.module#LoginRestorePageModule' },
  { path: 'trip-add', loadChildren: './trip-add/trip-add.module#TripAddPageModule' },
  { path: 'trip-confirm', loadChildren: './trip-confirm/trip-confirm.module#TripConfirmPageModule' },
  { path: 'trip-list', loadChildren: './trip-list/trip-list.module#TripListPageModule' },
  { path: 'country-list', loadChildren: './country-list/country-list.module#CountryListPageModule' },
  { path: 'country-add', loadChildren: './country-add/country-add.module#CountryAddPageModule' },
  { path: 'country-visa-list', loadChildren: './country-visa-list/country-visa-list.module#CountryVisaListPageModule' },
  { path: 'country-visa-add', loadChildren: './country-visa-add/country-visa-add.module#CountryVisaAddPageModule' },
  { path: 'profile', loadChildren: './profile/profile.module#ProfilePageModule' },

  { path: 'about', loadChildren: './about/about.module#AboutPageModule' },
  { path: 'contact', loadChildren: './contact/contact.module#ContactPageModule' },
  { path: 'onboard', loadChildren: './onboard/onboard.module#OnboardPageModule' },
  { path: 'profile-change-password', loadChildren: './profile-change-password/profile-change-password.module#ProfileChangePasswordPageModule' },
  { path: 'profile-change-username', loadChildren: './profile-change-username/profile-change-username.module#ProfileChangeUsernamePageModule' },
  { path: 'profile-change-picture', loadChildren: './profile-change-picture/profile-change-picture.module#ProfileChangePicturePageModule' }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
