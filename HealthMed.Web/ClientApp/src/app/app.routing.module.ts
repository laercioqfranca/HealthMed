import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';

const routes: Routes = [

  // REDIRECTS
  { path: '', redirectTo: '/login', pathMatch: 'full'},

  // ADMINISTRAÇÃO
        // Autenticação  

  { path: 'login', loadChildren: () => import('./auth/login/login.module').then(x => x.LoginModule) },

        // Usuários
  { path: 'medico/home', loadChildren: () => import('./home/medico/medico.module').then(x=>x.MedicoModule), 
    pathMatch:'full', 
    canActivate: [AuthGuard]
  },

  { path: 'paciente/home', loadChildren: () => import('./home/paciente/paciente.module').then(x=>x.PacienteModule), 
    pathMatch:'full', 
    canActivate: [AuthGuard]
  },
  
  { path: 'criar-conta', loadChildren: () => import('./criar-conta/criar-conta.module').then(x=>x.CriarContaModule), 
    pathMatch:'full',
  },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
