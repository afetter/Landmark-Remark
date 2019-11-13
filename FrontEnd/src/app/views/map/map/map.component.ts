import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { GeoLocationService } from '../../../_services/geo-location-service';
import { Observable } from 'rxjs';
import { MouseEvent } from '@agm/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from '../../../_services/authentication-service';
import { Message } from '../../../_models/message';
import { MatTableDataSource, MatSort, MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss']
})

export class MapComponent implements OnInit, AfterViewInit {

  lat = -33.835839;
  lng = 151.1989639;
  zoom = 12;
  //listOfMessages: Observable<any[]>;
  listOfMessages: Message[];
  form: FormGroup;
  currentUser: string;
  isReadOnly: boolean;


  dataSource = new MatTableDataSource<Message>();
  displayedColumns = ['user', 'text'];

  @ViewChild(MatSort, { static: false }) sort: MatSort;


  constructor(
    private fb: FormBuilder,
    private geoLocationService: GeoLocationService,
    private authenticationService: AuthenticationService,
    private snackBar: MatSnackBar
  ) {

  }

  ngAfterViewInit() {

    this.geoLocationService.getPosition().subscribe(
      (pos: Position) => {
        this.lat = +(pos.coords.latitude);
        this.lng = +(pos.coords.longitude);
      });

    this.dataSource.sort = this.sort;

  }

  onSubmit(id: number, form: FormGroup) {

    const data = {
      id: 0,
      lat: form.get('lat').value.toString(),
      lng: form.get('lng').value.toString(),
      text: form.get('message').value,
      user: this.authenticationService.loggedUser()
    };

    this.geoLocationService.update(+form.get('id').value, data)
      .subscribe(s => {

        this.snackBar.open('Message successfully created', 'Success', {
          duration: 5 * 1000,
        });
        this.loadListOfMessages();

      });

  }


  ngOnInit() {

    this.form = this.fb.group({
      id: 0,
      message: ['', Validators.required],
      lat: ['', Validators.required],
      lng: ['', Validators.required]
    });

    this.loadListOfMessages();

  }

  loadListOfMessages() {
    this.geoLocationService.get().subscribe(res => {
      this.dataSource.data = res;
      this.listOfMessages = res;
    });
  }

  mapClicked($event: MouseEvent) {

    if (this.authenticationService.loggedUser() === null) {

      this.snackBar.open('Please login first', 'Error', {
        duration: 5 * 1000,
      });

    } else {

      const data = {
        id: 0,
        lat: $event.coords.lat.toString(),
        lng: $event.coords.lng.toString(),
        text: '',
        user: this.authenticationService.loggedUser()
      };

      this.geoLocationService.add(data).subscribe(s => {
        this.loadListOfMessages();
      });
    }
  }

  selectMarker($event, user, id) {

    this.form.get('lat').setValue($event.latitude);
    this.form.get('lng').setValue($event.longitude);
    this.form.get('id').setValue(id);

    this.isReadOnly = this.authenticationService.loggedUser() !== user;

  }

  doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }
}
