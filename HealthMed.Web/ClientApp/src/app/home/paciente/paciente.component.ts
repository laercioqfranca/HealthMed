import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AgendaMedicaService } from 'src/app/core/services/agenda-medica.service';
import { AgendaPacienteService } from 'src/app/core/services/agenda-paciente.service';
import { EspecialidadeService } from 'src/app/core/services/especialidade.service';
import { NotificationService } from 'src/app/core/services/root/notification.service';
import { UsuarioService } from 'src/app/core/services/usuario.service';
import { AuthService } from 'src/app/services/root/auth.service';
import Swal from 'sweetalert2';

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
  agendaDoPaciente: any = [];

  idEspecialidade = new FormControl(null, [Validators.required]);
  idMedico = new FormControl(null, [Validators.required]);

  get idAgendaMedica() { return this.agendarConsultaForm.get('idAgendaMedica') }
  get idPaciente() { return this.agendarConsultaForm.get('idPaciente') }

  constructor(
    private notificationService: NotificationService,
    private especialidadeService: EspecialidadeService,
    private usuarioService: UsuarioService,
    private agendaMedicaService: AgendaMedicaService,
    private agendaPacienteService: AgendaPacienteService,
    private fb: FormBuilder,
    private authService: AuthService
  ) {
    this.authService.currentUser.subscribe((res:any) => this.idUsuario = res.id)
  }

  ngOnInit() {
    this.iniciarForm();
    this.carregarComboEspecialidade();
    this.carregarAgendaPaciente();
  }

  onSubmit() {

    let model = this.agendarConsultaForm.value;

    if (this.agendarConsultaForm.valid) {
      this.agendaPacienteService.create(model).subscribe({
        next: res => {
          if (res.success) {
            this.notificationService.showSuccess("Consulta agendada com sucesso!", "");
            this.limpar();
            this.agendaDoMedico = [];
            this.carregarAgendaPaciente();
          }
        }, error: e => {
          this.notificationService.showError("Ocorreu algum erro!", "");
        }
      })
    }

  }

  iniciarForm() {
    this.agendarConsultaForm = this.fb.group({
      idAgendaMedica: [null, Validators.required],
      idPaciente: [null, Validators.required]
    });
  }

  selecionarHorario(idAgenda: any, idHora: any, agendado: boolean) {
    if (!agendado) {
      this.idAgendaMedica?.setValue(idAgenda);
      this.idPaciente?.setValue(this.idUsuario);
      this.horarioSelecionado = { idAgenda, idHora };
    }
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

  carregarAgendaPaciente() {
    this.agendaPacienteService.getAll().subscribe({
      next: res => {
        if (res.success) {
          this.agendaDoPaciente = res.data;
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
          }
        }, error: e => {
          this.notificationService.showError("Ocorreu algum erro ao carregar o médico!", "Ops...");
        }
      });
    }
  }

  obterAgendaMedica(idMedico: any) {
    if (idMedico) {
      this.agendaMedicaService.getByIdMedico(idMedico)
        .subscribe({
          next: (res) => {
            this.agendaDoMedico = res.data;
          },
          error: (e) => {
            this.notificationService.showError("Ocorreu algum erro ao carregar a agenda do médico!", "Ops...");
          },
        });
    }
  }

  cancelarConsulta(idAgenda:any){
    this.agendaPacienteService.delete(idAgenda).subscribe({
      next: res => {
        this.modalSucesso();
        this.carregarAgendaPaciente();
      },error: e => {
        this.notificationService.showError("Ocorreu algum erro ao cancelar a consulta!", "Ops...");
      }
    })

  }

  modalCancelar(idAgenda:any){
    Swal.fire({
      html: `
        <br>  
        <h3 class='fw-bold'>Atenção!</h3>
        <br>
        <p class="mt-3 fw-bold">Deseja realmente cancelar esta consulta?</p>
      `,
      showConfirmButton: true,
      confirmButtonText: "SIM",
      confirmButtonColor: '#049D01',
      showDenyButton: true,
      denyButtonText: 'NÃO'
    }).then(e => {
      if(e.isConfirmed){
        this.cancelarConsulta(idAgenda);
      }
      Swal.close();
    })
  }
  
  modalCadastrar(){
    Swal.fire({
      html: `
        <br>  
        <h3 class='fw-bold'>Atenção!</h3>
        <br>
        <p class="mt-3 fw-bold">Confirmar agendamento?</p>
      `,
      showConfirmButton: true,
      confirmButtonText: "SIM",
      confirmButtonColor: '#049D01',
      showDenyButton: true,
      denyButtonText: 'NÃO'
    }).then(e => {
      if(e.isConfirmed){
        this.onSubmit();
      }
      Swal.close();
    })
  }

  modalSucesso(){
    Swal.fire({
      html: `
        <br>  
        <h3 class='fw-bold'>Sucesso!</h3>
        <br>
        <p class="mt-3 fw-bold">Consulta cancelada com sucesso!</p>
      `,
      showConfirmButton: true,
      confirmButtonText: "FECHAR",
      confirmButtonColor: '#049D01',
    }).then(e => {
      Swal.close();
    })
  }

  limpar() {
    this.agendarConsultaForm.reset();
    this.idEspecialidade.reset();
    this.idMedico.reset();
  }

}
