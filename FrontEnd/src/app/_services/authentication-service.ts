import { Observable, Subject } from 'rxjs';
import { User } from '../_models/user';
import { of } from 'rxjs';
import { Injectable } from '@angular/core';
import { DataService } from './data-service';
import { map } from 'rxjs/operators';

@Injectable()
export class AuthenticationService {


    constructor(private dataService: DataService) {

    }

    user = new Subject<string>();

    add(data: User): Observable<User> {
        return this.dataService.add<User>('User', data);
    }


    login(username: string, pwd: string) {
        return this.dataService.add<any>('User/login', { username, pwd });
    }

    saveUser(user: string) {
        this.user.next(user);
        localStorage.setItem('currentUser', user);
    }

    loggedUser() {
        return localStorage.getItem('currentUser');
    }

    logout() {
        this.user.next(null);
        localStorage.removeItem('currentUser');
    }
}
