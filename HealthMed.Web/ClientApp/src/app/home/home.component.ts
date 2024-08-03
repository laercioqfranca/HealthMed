import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/root/auth.service';
import { EnumTipoPerfil } from '../shared/utils/enums';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {

  enumTipoPerfil = EnumTipoPerfil;
  perfilUsuairo!: EnumTipoPerfil;
  constructor(private authService:AuthService

  ) {
    this.authService.currentUser.subscribe((res:any) => this.perfilUsuairo = res?.enumPerfil)
  }

  ngOnInit() {
  }

}
