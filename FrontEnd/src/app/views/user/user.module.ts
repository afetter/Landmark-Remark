import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { AddUserComponent } from './add-user/add-user.component';

import { MaterialModule } from '../../material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ShareModule } from '../share/share.module';


@NgModule({
  declarations: [AddUserComponent],
  imports: [
    MaterialModule,
    ShareModule,
    CommonModule,
    UserRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ], 

})
export class UserModule { }
