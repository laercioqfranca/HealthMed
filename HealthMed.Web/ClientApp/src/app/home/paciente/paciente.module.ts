import { NgModule } from '@angular/core';

import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/shared/shared.module';
import { PacienteComponent } from './paciente.component';

@NgModule({
  declarations: [
    PacienteComponent
  ],

  imports:[
    SharedModule,
    CommonModule,
    RouterModule.forChild([
        { path: '', component: PacienteComponent },
      ]),
  ]

})
export class PacienteModule { }
