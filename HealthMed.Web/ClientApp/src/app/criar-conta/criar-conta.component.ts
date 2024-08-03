import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { UsuarioService } from '../core/services/usuario.service';
import { Router } from '@angular/router';
import { EnumTipoPerfil } from '../shared/utils/enums';
import { EspecialidadeService } from '../core/services/especialidade.service';
import { PerfilService } from '../core/services/perfil.service';
import { NotificationService } from '../core/services/root/notification.service';

@Component({
  selector: 'app-criar-conta',
  templateUrl: './criar-conta.component.html',
  styleUrls: ['./criar-conta.component.css']
})
export class CriarContaComponent implements OnInit {

  criarContaForm!: FormGroup;
  enumTipoPerfil = EnumTipoPerfil;
  especialidadeList: any = [];
  perfilList: any = [];

  tipoPerfil = new FormControl(1, Validators.required);

  get idPerfil() { return this.criarContaForm.get('idPerfil') };
  get idEspecialidade() { return this.criarContaForm.get('idEspecialidade') };
  get crm() { return this.criarContaForm.get('crm') };
  get nome() { return this.criarContaForm.get('nome') };
  get cpf() { return this.criarContaForm.get('cpf') };
  get email() { return this.criarContaForm.get('email') };
  get senha() { return this.criarContaForm.get('senha') };

  constructor(
    private usuarioService: UsuarioService,
    private router: Router,
    private notificationService: NotificationService,
    private fb: FormBuilder,
    private especialidadeService: EspecialidadeService,
    private perfilService: PerfilService,
  ) { }

  ngOnInit() {
    this.iniciarForm();
  }

  iniciarForm() {

    this.tipoPerfil?.setValue(EnumTipoPerfil.Paciente);

    this.criarContaForm = this.fb.group({
      idPerfil: [null],
      idEspecialidade: [null],
      crm: [null],
      nome: [null, Validators.required],
      cpf: [null, Validators.required],
      email: [null, [Validators.required, Validators.email]],
      senha: [null, [Validators.required, Validators.minLength(8)]]
    });

    this.carregarComboEspecialidade();
    this.carregarPerfis();
  }

  carregarComboEspecialidade(){
    this.especialidadeService.getAll().subscribe({
      next: res => {
        if(res.success){
          this.especialidadeList = res.data;
        }
      }, error: e => {
        // this.notificationService.showError("Ocorreu algum erro ao carregar as especialidades!", "Ops...");
      }
    });
  }

  carregarPerfis(){
    this.perfilService.getAll().subscribe({
      next: res => {
        if(res.success){
          this.perfilList = res.data;
          this.changeTipoPerfil();
        }
      }, error: e => {
        // this.notificationService.showError("Ocorreu algum erro ao carregar os Perfis!", "Ops...");
      }
    });
  }

  onSubmit() {
    if (this.criarContaForm.valid) {
      let model = this.criarContaForm?.getRawValue();
      this.usuarioService.create(model).subscribe({
        next: (res: any) => {
          if (res?.success) {
            this.notificationService.showSuccess('Conta criada com sucesso!', '');
            this.criarContaForm.reset();
            this.iniciarForm();
            this.router.navigateByUrl('/login');
          }
        },
        error: (e) => {
          // this.notificationService.showError("Ocorreu algum erro ao criar a conta!", "Ops...");
        },
      });
    }
  }

  changeTipoPerfil() {
    if (this.tipoPerfil?.value == EnumTipoPerfil.Medico) {
      const idPerfil = this.perfilList.filter((p:any) => p.idTipoPerfil == EnumTipoPerfil.Medico)
      this.idPerfil?.setValue(idPerfil[0].id);
    } 

    if (this.tipoPerfil?.value == EnumTipoPerfil.Paciente) {
      const idPerfil = this.perfilList.filter((p:any) => p.idTipoPerfil == EnumTipoPerfil.Paciente)
      this.idPerfil?.setValue(idPerfil[0].id);
    } 
  }

  cancelar() {
    this.criarContaForm.reset();
    this.router.navigateByUrl('/login');
  }

}
