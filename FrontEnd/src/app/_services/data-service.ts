import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';


@Injectable()
export class DataService {

    private actionUrl: string;

    constructor(
        private http: HttpClient) {
        this.actionUrl = environment.ServerWithApiUrl;
    }

    public getAll<T>(action: string): Observable<T> {
        return this.http.get<T>(this.actionUrl + action);
    }

    public add<T>(action: string, itemName: any): Observable<T> {
        const toAdd = JSON.stringify(itemName);
        return this.http.post<T>(this.actionUrl + action, toAdd);
    }

    public patch<T>(action: string, itemName: any): Observable<T> {
        const toAdd = JSON.stringify(itemName);
        return this.http.patch<T>(this.actionUrl + action, toAdd);
    }
}
