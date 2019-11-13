import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Message } from '../_models/message';
import { DataService } from './data-service';

@Injectable()
export class GeoLocationService {

    constructor(private dataService: DataService) { }

    get(): Observable<Message[]> {
        return this.dataService.getAll<Message[]>('Message');
    }

    add(data: Message): Observable<Message> {
        return this.dataService.add<Message>('Message', data);
    }

    update(id: number, data: Message): Observable<Message> {
        return this.dataService.patch<Message>(`Message/${id}`, data);
    }


    getPosition(): Observable<Position> {
        return Observable.create(
            (observer) => {
                navigator.geolocation.watchPosition((pos: Position) => {
                    observer.next(pos);
                }),
                    // tslint:disable-next-line:no-unused-expression
                    () => {
                        console.log('Position is not available');
                    },
                    // tslint:disable-next-line:no-unused-expression
                    {
                        enableHighAccuracy: true
                    };
            });
    }
}