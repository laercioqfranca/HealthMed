import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NotificationService } from '../../services/root/notification.service';
import { LoginService } from '../../services/root/login.service';
import { ILogin } from '../../interfaces/interfaces';
import { JwtService } from '../../services/root/jwt.service';
import { Router } from '@angular/router';
import { AuthService } from '../../services/root/auth.service';
import { EnumTipoPerfil } from 'src/app/shared/utils/enums';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formLogin!: FormGroup;
  
  constructor(
    private notificationService: NotificationService,
    private loginService: LoginService,
    private jwtService: JwtService,
    private router: Router,
    private authService: AuthService,
    private fb : FormBuilder
    ) { }

  ngOnInit() {
    this.criaFormLogin();
  }

  criaFormLogin(){
    this.formLogin = this.fb.group({
      login:[null, [Validators.required, Validators.email]],
      senha: [null, Validators.required]
    })
  }

  onSubmit(){

    if(this.formLogin.valid){
      this.loginService.login(this.formLogin?.value).subscribe({
        next: (res: any) => {
  
          if (res.success == true) {
            const userJwt = <ILogin>res.data;
            const usuario = this.jwtService.decodeToken(userJwt.accessToken);

            if(usuario?.enumPerfil == EnumTipoPerfil.Medico){
              this.router.navigateByUrl('/medico/home');
            }

            if(usuario?.enumPerfil == EnumTipoPerfil.Paciente){
              this.router.navigateByUrl('/paciente/home');
            }

            this.authService.setSession(userJwt);
  
          }
  
        },
        error: (e) => {
          this.formLogin.get('senha')?.setValue('');
          this.notificationService.showError('Ocorreu algum erro!', '');
        },
      });
    }
  }

}
