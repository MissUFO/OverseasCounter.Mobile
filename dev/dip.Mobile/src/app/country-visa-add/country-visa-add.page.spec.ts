import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CountryVisaAddPage } from './country-visa-add.page';

describe('CountryVisaAddPage', () => {
  let component: CountryVisaAddPage;
  let fixture: ComponentFixture<CountryVisaAddPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CountryVisaAddPage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryVisaAddPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
