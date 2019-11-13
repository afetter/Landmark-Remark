import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from './_services/authentication-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent  {

  loggedUser: string;

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router
    ) {
      this.loggedUser = authenticationService.loggedUser();
      authenticationService.user.subscribe((nextValue) => {
        this.loggedUser = nextValue;  // this will happen on every change
     });
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/']);
  }
}
