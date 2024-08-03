import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AgendaMedicaService } from 'src/app/core/services/agenda-medica.service';
import { HorarioService } from 'src/app/core/services/horario.service';
import { NotificationService } from 'src/app/core/services/root/notification.service';
import { AgendaMedicaFiltroModel } from 'src/app/models/agendaMedicaFiltroModel';
import { AuthService } from 'src/app/services/root/auth.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-medico',
  templateUrl: './medico.component.html',
  styleUrls: ['./medico.component.css']
})
export class MedicoComponent implements OnInit {

  agendaForm!: FormGroup;
  idMedico!:any;
  horarioList!:any;
  agendaMedica: any = [];
  mostrarCriarEvento: boolean = true;

  get content(): FormArray { return this.agendaForm.get('content') as FormArray; }
  get data() { return this.agendaForm.get('data') }

  constructor(
    private notificationService: NotificationService,
    private fb: FormBuilder,
    private horarioService: HorarioService,
    private agendaService: AgendaMedicaService,
    private authService: AuthService

    ) { 
      this.authService.currentUser.subscribe((res:any) => this.idMedico = res.id)
    }  
  
  ngOnInit() {
    this.iniciarForm();
    this.listarHorarios();
    this.listarAgendaPorMedico();
  }
    
  iniciarForm(){
    this.agendaForm = this.fb.group({
      data: [null, Validators.required],
      content: this.fb.array([
      ])
    });
    this.content.disable();
  }

  addDataHorario(dataSelecionada:any, horarioSelecionado:any){
    this.content.clear();
    if(horarioSelecionado){
      horarioSelecionado.forEach((horario:any) => {

        const data = new Date(dataSelecionada);
        data.setHours(-3);
        data.setMinutes(0);
        data.setSeconds(0);

        const dataHorario = this.fb.group({
          data: [data],
          idHorario: [horario.id]
        })
        this.content.push(dataHorario);
      });
    }
  }

  onSubmit(){
    if(this.agendaForm.valid){
      let model = this.agendaForm.getRawValue()
      this.cadastrarAgenda(model);
    }
  }

  listarHorarios(){
    this.horarioService.getAll()
      .subscribe({
        next: (res) => {
          const horarioList = res.data;
          this.horarioList = this.ordenarHorarioList(horarioList);
        },
        error: (e) => {
          this.notificationService.showError("Ocorreu algum erro ao carregar os Horários!", "Ops...");
        },
      });
  }

  ordenarHorarioList(lista:any){
    return lista.sort(function(a:any, b:any){
      if (a.descricao < b.descricao) {
        return -1;
      }
      if (a.descricao > b.descricao) {
        return 1;
      }
      return 0;
    });
  }

  listarAgendaPorMedico(){
    this.agendaService.getByIdMedico(this.idMedico)
      .subscribe({
        next: (res) => {
          this.agendaMedica = res.data;
        },
        error: (e) => {
          this.notificationService.showError("Ocorreu algum erro ao carregar os Horários!", "Ops...");
        },
      });
  }

  cadastrarAgenda(model:any){
    this.agendaService.create(model).subscribe({
      next:(res) => {
        if (res?.success) {
          this.notificationService.showSuccess('Agenda cadastrada com sucesso!', '');
          this.agendaForm.reset();
          this.listarAgendaPorMedico();
        }
      },
      error: (e) => {
        this.notificationService.showError("Ocorreu algum erro ao cadastrar a agenda!", "Ops...");
      },
    });
  }

  excluirAgenda(dataAgenda:any){
    this.agendaService.deletePorData(dataAgenda).subscribe({
      next: res => {
        this.modalSucesso();
        this.listarAgendaPorMedico();
      },error: e => {
        this.notificationService.showError("Ocorreu algum erro ao cancelar a consulta!", "Ops...");
      }
    })

  }

  excluirHorario(idAgenda:any){
    this.agendaService.deleteAgenda(idAgenda).subscribe({
      next: res => {
        this.modalSucesso();
        this.listarAgendaPorMedico();
      },error: e => {
        this.notificationService.showError("Ocorreu algum erro ao cancelar a consulta!", "Ops...");
      }
    })
  }

  modalExcluir(dataAgenda:any){
    Swal.fire({
      html: `
        <br>  
        <h3 class='fw-bold'>Atenção!</h3>
        <br>
        <p class="mt-3 fw-bold">Deseja realmente remover esta agenda?</p>
      `,
      showConfirmButton: true,
      confirmButtonText: "SIM",
      confirmButtonColor: '#049D01',
      showDenyButton: true,
      denyButtonText: 'NÃO'
    }).then(e => {
      if(e.isConfirmed){
        this.excluirAgenda(dataAgenda);
      }
      Swal.close();
    })
  }

  modalExcluirHorario(idAgenda:any){
    Swal.fire({
      html: `
        <br>  
        <h3 class='fw-bold'>Atenção!</h3>
        <br>
        <p class="mt-3 fw-bold">Deseja realmente remover este horário?</p>
      `,
      showConfirmButton: true,
      confirmButtonText: "SIM",
      confirmButtonColor: '#049D01',
      showDenyButton: true,
      denyButtonText: 'NÃO'
    }).then(e => {
      if(e.isConfirmed){
        this.excluirHorario(idAgenda);
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
        <p class="mt-3 fw-bold">Agenda removida com sucesso!</p>
      `,
      showConfirmButton: true,
      confirmButtonText: "FECHAR",
      confirmButtonColor: '#049D01',
    }).then(e => {
      Swal.close();
    })
  }

  limpar(){
    this.agendaForm.reset();
    this.iniciarForm();
  }

}
