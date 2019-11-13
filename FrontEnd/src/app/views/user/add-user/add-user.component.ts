import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { UserService } from '../../../_services/user-service';
import { MatSnackBar } from '@angular/material';
import { config } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.scss']
})
export class AddUserComponent implements OnInit {

  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private snackBar: MatSnackBar,
    private router: Router) { }

  ngOnInit() {
    this.form = this.fb.group({
      username: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  onSubmit($event) {

    const data = {
      username: $event.username,
      pwd: $event.pwd
    };
    
    this.userService.add(data).subscribe(n => {

      this.router.navigate(['/']).then((navigated: boolean) => {

        if (navigated) {
          this.snackBar.open('Thank you for your registration', 'Success', {
            duration: 5 * 1000,
          });

        }
      });
    });

  }

}
