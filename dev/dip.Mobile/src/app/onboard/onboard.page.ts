import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { MenuController, Slides } from '@ionic/angular';

import { Storage } from '@ionic/storage';

@Component({
  selector: 'app-onboard',
  templateUrl: './onboard.page.html',
  styleUrls: ['./onboard.page.scss'],
})
export class OnboardPage implements OnInit {
  showSkip = true;

  @ViewChild('slides') slides: Slides;

  constructor(
    public menu: MenuController,
    public router: Router,
    public storage: Storage) 
  {

  }

  startApp() {
      this.router
      .navigateByUrl('/tabs/(home:home)')
      .then(() => this.storage.set('onboarded', 'true'));
  }

  onSlideChangeStart(event) {
    this.showSkip = !event.target.isEnd();
  }

  ionViewWillEnter() {
    this.menu.enable(false);
  }

  ionViewDidEnter() {
    this.slides.update();
  }

  ionViewDidLeave() {
    // enable the root left menu when leaving the tutorial page
    this.menu.enable(true);
  }

  ngOnInit() {
  }

}
