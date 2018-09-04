import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TripAddPage } from './trip-add.page';

describe('TripAddPage', () => {
  let component: TripAddPage;
  let fixture: ComponentFixture<TripAddPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TripAddPage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TripAddPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
