import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MaterialModule } from './material/material.module';
import { GeoLocationService } from './_services/geo-location-service';
import { UserService } from './_services/user-service';
import { MatSnackBar } from '@angular/material';
import { ShareModule } from './views/share/share.module';
import { AuthenticationService } from './_services/authentication-service';
import { DataService } from './_services/data-service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from './_helper/jwt.interceptor';
import { ErrorInterceptor } from './_helper/error.interceptor';


@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [

    ShareModule,
    MaterialModule,
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,

  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    GeoLocationService,
    UserService,
    MatSnackBar,
    AuthenticationService,
    DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
