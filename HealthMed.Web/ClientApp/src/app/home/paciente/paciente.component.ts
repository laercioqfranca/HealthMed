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

  agendarConsultaForm!:FormGroup;
  idUsuario!:any;

  mostrarCriarEvento: boolean = true;
  especialidadeList: any[] = [];
  medicoList: any = [];
  agendaList: any = [];

  idEspecialidade = new FormControl(null, [Validators.required]); 
  idMedico = new FormControl(null, [Validators.required]); 

  get idAgendaMedica() {return this.agendarConsultaForm.get('idAgendaMedica')}
  get idPaciente() {return this.agendarConsultaForm.get('idPaciente')}

  constructor(
    private notificationService: NotificationService,
    private especialidadeService: EspecialidadeService,
    private usuarioService: UsuarioService,
    private agendaMedicaService: AgendaMedicaService,
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
  
  onSubmit(){

  }

  iniciarForm(){
    this.agendarConsultaForm = this.fb.group({
      idAgendaMedica: [null, Validators.required],
      idPaciente: [null, Validators.required]
    });
  }

  horarioSelecionado: { idAgenda: any, idHora: any } | null = null;

  selecionarHorario(idAgenda: any, idHora:any){
    this.idAgendaMedica?.setValue(idAgenda);
    this.idPaciente?.setValue(this.idUsuario);

    this.horarioSelecionado = { idAgenda, idHora };

    console.log(this.agendarConsultaForm.value)

  }


  isHorarioSelecionado(agendaId: number, horaId: number): boolean {
    return this.horarioSelecionado?.idAgenda === agendaId && this.horarioSelecionado?.idHora === horaId;
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

  obterMedicoPorEspecialidade(idEspecialidade:any){
    if(idEspecialidade){
      this.usuarioService.getListByIdEspecialidade(idEspecialidade).subscribe({
        next: res => {
          if(res.success){
            this.medicoList = res.data;
            console.log(this.medicoList)
          }
        }, error: e => {
          this.notificationService.showError("Ocorreu algum erro ao carregar as especialidades!", "Ops...");
        }
      });
    }
  }

  obterAgendaMedica(idMedico:any){
    if(idMedico){

      this.agendaList = [{
        id: '537e5a56-149d-42a0-ad5d-033357e9554c',
        data: '01/06/2024',
        horas: [
          {
            "id": "537e5a56-149d-42a0-ad5d-033357e9554c",
            "descricao": "09:30"
          },
          {
            "id": "a3de6e59-86e5-40b1-8d15-066e518963e5",
            "descricao": "18:00"
          },
          {
            "id": "c7193960-5e07-4b92-a9eb-0d58ab46d017",
            "descricao": "19:00"
          },
          {
            "id": "79a0f454-55db-4da3-982f-306851f41a28",
            "descricao": "15:00"
          },
          {
            "id": "f890b9e5-918e-4f16-94c1-3319040790df",
            "descricao": "08:30"
          }
        ],
      },
      {
        id: 'c7193960-5e07-4b92-a9eb-0d58ab46d017',
        data: '05/06/2024',
        horas: [
          {
            "id": "537e5a56-149d-42a0-ad5d-033357e9554c",
            "descricao": "09:30"
          },
          {
            "id": "c7193960-5e07-4b92-a9eb-0d58ab46d017",
            "descricao": "19:00"
          },
          {
            "id": "79a0f454-55db-4da3-982f-306851f41a28",
            "descricao": "15:00"
          },
        ]
      },
      {
        id: 'b1a825f5-6fe2-4d0a-9543-ab1f984ce68c',
        data: '09/08/2024',
        horas: [
          {
            "id": "d1d0e272-52eb-41cf-a929-98d21a977f61",
            "descricao": "15:30"
          },
          {
            "id": "36cd1cbc-08c7-42a3-923c-aa6119c79ba6",
            "descricao": "10:00"
          },
          {
            "id": "b1a825f5-6fe2-4d0a-9543-ab1f984ce68c",
            "descricao": "09:00"
          },
          {
            "id": "7bb8d4f3-6bd8-4207-87f3-af935dbda8be",
            "descricao": "12:00"
          },
          {
            "id": "0ccfd793-1c91-4162-a858-bbe4802207b4",
            "descricao": "17:30"
          },
          {
            "id": "a8e98a5d-5133-4fa2-9569-c5b81f9c39dc",
            "descricao": "16:00"
          }
        ]
      },
      {
        id: 'a8e98a5d-5133-4fa2-9569-c5b81f9c39dc',
        data: '10/08/2024',
        horas: [
          {
            "id": "b1a825f5-6fe2-4d0a-9543-ab1f984ce68c",
            "descricao": "09:00"
          },
          {
            "id": "7bb8d4f3-6bd8-4207-87f3-af935dbda8be",
            "descricao": "12:00"
          },
          {
            "id": "0ccfd793-1c91-4162-a858-bbe4802207b4",
            "descricao": "17:30"
          },
          {
            "id": "a8e98a5d-5133-4fa2-9569-c5b81f9c39dc",
            "descricao": "16:00"
          }
        ]
      }
    ]

      // this.agendaMedicaService.getByIdMedico(idMedico).subscribe({
      //   next: res => {
      //     if(res.success){
      //       console.log(res.data);
      //     }
      //   }, error: e => {
      //     this.notificationService.showError("Ocorreu algum erro ao carregar as especialidades!", "Ops...");
      //   }
      // });
    }
  }

  limpar(){
    this.agendarConsultaForm.reset();
    this.idEspecialidade.reset();
  }

}
