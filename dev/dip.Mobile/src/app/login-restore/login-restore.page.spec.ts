import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginRestorePage } from './login-restore.page';

describe('LoginRestorePage', () => {
  let component: LoginRestorePage;
  let fixture: ComponentFixture<LoginRestorePage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoginRestorePage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginRestorePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
