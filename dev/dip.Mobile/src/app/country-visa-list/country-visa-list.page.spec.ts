import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CountryVisaListPage } from './country-visa-list.page';

describe('CountryVisaListPage', () => {
  let component: CountryVisaListPage;
  let fixture: ComponentFixture<CountryVisaListPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CountryVisaListPage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryVisaListPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
