import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../../_services/authentication-service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit() {
  }

  onSubmit($event) {
    this.authenticationService.login($event.username, $event.pwd)
      .subscribe(d => {

        this.authenticationService.saveUser($event.username);
        this.router.navigate(['/']).then((navigated: boolean) => {
          if (navigated) {
            this.snackBar.open('You are welcome', 'Success', {
              duration: 3 * 1000,
            });
          }
        });

      });
  }

}
