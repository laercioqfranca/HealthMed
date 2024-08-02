import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AgendaMedicaService } from 'src/app/core/services/agenda-medica.service';
import { EspecialidadeService } from 'src/app/core/services/especialidade.service';
import { NotificationService } from 'src/app/core/services/root/notification.service';
import { UsuarioService } from 'src/app/core/services/usuario.service';
import { AuthService } from 'src/app/services/root/auth.service';

@Component({
  selector: 'app-paciente',
  templateUrl: './paciente.component.html',
  styleUrls: ['./paciente.component.css']
})
export class PacienteComponent implements OnInit {

  agendarConsultaForm!: FormGroup;
  idUsuario!: any;

  horarioSelecionado: { idAgenda: any, idHora: any } | null = null;

  mostrarCriarEvento: boolean = true;
  especialidadeList: any[] = [];
  medicoList: any = [];
  agendaDoMedico: any = [];

  idEspecialidade = new FormControl(null, [Validators.required]);
  idMedico = new FormControl(null, [Validators.required]);

  get idAgendaMedica() { return this.agendarConsultaForm.get('idAgendaMedica') }
  get idPaciente() { return this.agendarConsultaForm.get('idPaciente') }

  constructor(
    private notificationService: NotificationService,
    private especialidadeService: EspecialidadeService,
    private usuarioService: UsuarioService,
    private agendaService: AgendaMedicaService,
    private fb: FormBuilder,
    private authService: AuthService
  ) {
    const usuario = this.authService.currentUserValue
    this.idUsuario = usuario?.id;
  }

  ngOnInit() {
    this.iniciarForm();
    this.carregarComboEspecialidade();
  }

  onSubmit() {

  }

  iniciarForm() {
    this.agendarConsultaForm = this.fb.group({
      idAgendaMedica: [null, Validators.required],
      idPaciente: [null, Validators.required]
    });
  }

  selecionarHorario(idAgenda: any, idHora: any) {
    this.idAgendaMedica?.setValue(idAgenda);
    this.idPaciente?.setValue(this.idUsuario);

    this.horarioSelecionado = { idAgenda, idHora };

    console.log(this.agendarConsultaForm.value)

  }

  isHorarioSelecionado(agendaId: number, horaId: number): boolean {
    return this.horarioSelecionado?.idAgenda === agendaId && this.horarioSelecionado?.idHora === horaId;
  }

  carregarComboEspecialidade() {
    this.especialidadeService.getAll().subscribe({
      next: res => {
        if (res.success) {
          this.especialidadeList = res.data;
        }
      }, error: e => {
        this.notificationService.showError("Ocorreu algum erro ao carregar as especialidades!", "Ops...");
      }
    });
  }

  obterMedicoPorEspecialidade(idEspecialidade: any) {
    if (idEspecialidade) {
      this.usuarioService.getListByIdEspecialidade(idEspecialidade).subscribe({
        next: res => {
          if (res.success) {
            this.medicoList = res.data;
            console.log(this.medicoList)
          }
        }, error: e => {
          this.notificationService.showError("Ocorreu algum erro ao carregar o médico!", "Ops...");
        }
      });
    }
  }

  obterAgendaMedica(idMedico: any) {
    if (idMedico) {
      this.agendaService.getByIdMedico(idMedico)
        .subscribe({
          next: (res) => {
            this.agendaDoMedico = res.data;
            console.log(this.agendaDoMedico)
          },
          error: (e) => {
            this.notificationService.showError("Ocorreu algum erro ao carregar a agenda do médico!", "Ops...");
          },
        });
    }
  }

  limpar() {
    this.agendarConsultaForm.reset();
    this.idEspecialidade.reset();
  }

}
