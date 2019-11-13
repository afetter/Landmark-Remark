import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { User } from '../../../_models/user';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-user-pwd',
  templateUrl: './user-pwd.component.html',
  styleUrls: ['./user-pwd.component.scss']
})
export class UserPwdComponent implements OnInit {

  @Input() title: string;
  @Output() childSubmit: EventEmitter<User> = new EventEmitter();

  form: FormGroup;

  constructor(
    private fb: FormBuilder) { }

  ngOnInit() {
    this.form = this.fb.group({
      username: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  onSubmit(form: FormGroup) {

    this.childSubmit.emit({ username: form.get('username').value, pwd: form.get('password').value });

  }

}
