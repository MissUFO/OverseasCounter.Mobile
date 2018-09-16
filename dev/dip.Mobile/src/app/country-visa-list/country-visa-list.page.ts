import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-country-visa-list',
  templateUrl: './country-visa-list.page.html',
  styleUrls: ['./country-visa-list.page.scss'],
})
export class CountryVisaListPage implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  doRefresh(event) {
    console.log('Begin async operation');

    setTimeout(() => {
      console.log('Async operation has ended');
      event.target.complete();
    }, 2000);
  }
}
