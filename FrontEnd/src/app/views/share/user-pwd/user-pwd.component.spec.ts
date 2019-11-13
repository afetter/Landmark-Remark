import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserPwdComponent } from './user-pwd.component';

describe('UserPwdComponent', () => {
  let component: UserPwdComponent;
  let fixture: ComponentFixture<UserPwdComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserPwdComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserPwdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
