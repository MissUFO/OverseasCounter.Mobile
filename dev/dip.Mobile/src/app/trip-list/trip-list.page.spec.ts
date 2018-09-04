import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TripListPage } from './trip-list.page';

describe('TripListPage', () => {
  let component: TripListPage;
  let fixture: ComponentFixture<TripListPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TripListPage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TripListPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
