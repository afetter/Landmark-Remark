import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material';



@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(
        private snackBar: MatSnackBar
        ) {}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(catchError(err => {

            let error = 'Exception Error';
            if ((err.error.errors !== undefined && err.error.errors.length >= 1)) {
                error = err.error.errors[0] || err.statusText;
            }

            this.snackBar.open(error, 'Error', {
                duration: 5 * 1000,
              });

            return throwError(error);
        }));
    }
}
