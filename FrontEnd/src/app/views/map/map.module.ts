import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MapRoutingModule } from './map-routing.module';
import { MapComponent } from './map/map.component';
import { environment } from '../../../environments/environment';
import { AgmCoreModule } from '@agm/core';
import { MaterialModule } from '../../material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    MapComponent
  ],
  imports: [

    AgmCoreModule.forRoot({
      apiKey: environment.GoogleMapsKey
    }),
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    MapRoutingModule
  ]
})
export class MapModule { }
