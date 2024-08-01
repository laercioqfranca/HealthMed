import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { UsuarioService } from '../services/usuario.service';
import { Router } from '@angular/router';
import { NotificationService } from '../services/root/notification.service';
import { EnumTipoPerfil } from '../shared/utils/enums';
import { EspecialidadeService } from '../core/services/especialidade.service';

@Component({
  selector: 'app-criar-conta',
  templateUrl: './criar-conta.component.html',
  styleUrls: ['./criar-conta.component.css']
})
export class CriarContaComponent implements OnInit {

  criarContaForm!: FormGroup;
  enumTipoPerfil = EnumTipoPerfil;
  especialidadeList: any = [];

  get tipoPerfil() { return this.criarContaForm.get('tipoPerfil') };
  get nome() { return this.criarContaForm.get('nome') };
  get cpf() { return this.criarContaForm.get('cpf') };
  get email() { return this.criarContaForm.get('email') };
  get senha() { return this.criarContaForm.get('senha') };

  constructor(
    private usuarioService: UsuarioService,
    private router: Router,
    private notificationService: NotificationService,
    private fb: FormBuilder,
    private especialidadeService: EspecialidadeService
  ) { }

  ngOnInit() {
    this.iniciarForm();
  }

  iniciarForm() {
    this.criarContaForm = this.fb.group({
      tipoPerfil: [null, Validators.required],
      nome: [{ value: null, disabled: true }, Validators.required],
      cpf: [{ value: null, disabled: true }, Validators.required],
      email: [{ value: null, disabled: true }, [Validators.required, Validators.email]],
      senha: [{ value: null, disabled: true }, [Validators.required, Validators.minLength(8)]]
    });

    this.carregarComboEspecialidade();
  }

  carregarComboEspecialidade(){

    this.especialidadeService.getAll().subscribe({
      next: res => {
        if(res.success){
          this.especialidadeList = res.data;
        }
      }, error: e => {
        this.notificationService.showError("Ocorreu algum erro ao carregar as especialidades!", "Ops...");
      }
    });

  }

  onSubmit() {
    if (this.criarContaForm.valid) {
      this.usuarioService.create(this.criarContaForm?.value).subscribe({
        next: (res: any) => {
          if (res?.success) {
            this.notificationService.showSuccess('Conta criada com sucesso!', '');
            this.criarContaForm.reset();
            this.router.navigateByUrl('/login');
          }
        },
        error: (e) => {
          this.notificationService.showError("Ocorreu algum erro ao criar a conta!", "Ops...");
        },
      });
    }
  }

  changeTipoPerfil() {
    let tipoPerfil = this.tipoPerfil?.value;
    this.criarContaForm.reset();
    this.criarContaForm.enable();
    this.tipoPerfil?.setValue(tipoPerfil);

    if (this.tipoPerfil?.value == EnumTipoPerfil.Medico) {
      this.criarContaForm.addControl('crm', this.fb.control(null, Validators.required));
      this.criarContaForm.addControl('idEspecialidade', this.fb.control(null, Validators.required));
    } else {
      this.criarContaForm.removeControl('crm');
      this.criarContaForm.removeControl('idEspecialidade');
    }
  }

  cancelar() {
    this.criarContaForm.reset();
    this.router.navigateByUrl('/login');
  }

}
