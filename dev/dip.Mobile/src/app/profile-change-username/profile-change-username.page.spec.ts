import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileChangeUsernamePage } from './profile-change-username.page';

describe('ProfileChangeUsernamePage', () => {
  let component: ProfileChangeUsernamePage;
  let fixture: ComponentFixture<ProfileChangeUsernamePage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfileChangeUsernamePage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfileChangeUsernamePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
