import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TripConfirmPage } from './trip-confirm.page';

describe('TripConfirmPage', () => {
  let component: TripConfirmPage;
  let fixture: ComponentFixture<TripConfirmPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TripConfirmPage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TripConfirmPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
