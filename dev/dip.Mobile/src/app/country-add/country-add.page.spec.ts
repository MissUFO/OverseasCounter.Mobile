import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CountryAddPage } from './country-add.page';

describe('CountryAddPage', () => {
  let component: CountryAddPage;
  let fixture: ComponentFixture<CountryAddPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CountryAddPage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryAddPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
