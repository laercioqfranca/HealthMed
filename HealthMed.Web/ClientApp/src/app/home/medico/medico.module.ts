import { NgModule } from '@angular/core';

import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/shared/shared.module';
import { MedicoComponent } from './medico.component';

@NgModule({
  declarations: [
    MedicoComponent
  ],

  imports:[
    SharedModule,
    CommonModule,
    RouterModule.forChild([
        { path: '', component: MedicoComponent },
      ]),
  ]

})
export class MedicoModule { }
