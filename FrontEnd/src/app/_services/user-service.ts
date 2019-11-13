import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { of } from 'rxjs';
import { Injectable } from '@angular/core';
import { DataService } from './data-service';

@Injectable()
export class UserService {

    constructor(private dataService: DataService) {

    }
    add(data: User): Observable<User> {
        return this.dataService.add<User>('User', data);
    }

}