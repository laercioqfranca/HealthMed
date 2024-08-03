import { NgModule } from '@angular/core';

import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/shared/shared.module';
import { PacienteComponent } from './paciente/paciente.component';
import { MedicoComponent } from './medico/medico.component';
import { AuthGuard } from '../auth/auth.guard';
import { HomeComponent } from './home.component';

@NgModule({
  imports:[
    SharedModule,
    CommonModule,
    RouterModule.forChild([
        { path: '', component: HomeComponent,
          pathMatch:'full',
          canActivate: [AuthGuard]
        },
        { path: 'paciente', component: PacienteComponent,
          pathMatch:'full',
          canActivate: [AuthGuard]
        },
        { path: 'medico', component: MedicoComponent,
          pathMatch:'full',
          canActivate: [AuthGuard]
        },
      ]),
  ],
  declarations: [
    PacienteComponent,
    MedicoComponent,
    HomeComponent
  ],
})
export class HomeModule { }
