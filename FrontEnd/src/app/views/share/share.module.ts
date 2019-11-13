import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MaterialModule } from '../../material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserPwdComponent } from './user-pwd/user-pwd.component';

@NgModule({
  declarations: [ UserPwdComponent],

  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [ UserPwdComponent ]
})

export class ShareModule { }
