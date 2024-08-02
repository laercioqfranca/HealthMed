import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AgendaMedicaService } from 'src/app/core/services/agenda-medica.service';
import { HorarioService } from 'src/app/core/services/horario.service';
import { NotificationService } from 'src/app/core/services/root/notification.service';
import { AgendaMedicaFiltroModel } from 'src/app/models/agendaMedicaFiltroModel';
import { AuthService } from 'src/app/services/root/auth.service';

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
      const usuario = this.authService.currentUserValue;
      this.idMedico = usuario?.id;
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

  // obterEventoPorId(id:any){
  //   // this.eventoService.getById(id)
  //   //   .subscribe({
  //   //     next: (res) => {
  //   //       this.evento = res.data;
  //   //       this.carregarDados(); // carrega os dados no formulário
  //   //     },
  //   //     error: (e) => {
  //   //       this.notificationService.showError("Ocorreu algum erro ao carregar o evento!", "Ops...");
  //   //     },
  //   //   });
  // }

  // listarEventos(){
  //   // this.eventoService.getAll()
  //   //   .subscribe({
  //   //     next: (res) => {
  //   //       this.listaEventos = res.data;

  //   //       this.listaEventos.forEach(element => {
  //   //         element.data = new Date(element.data).toLocaleDateString();
  //   //       });
          
  //   //     },
  //   //     error: (e) => {
  //   //       this.notificationService.showError("Ocorreu algum erro ao carregar os eventos!", "Ops...");
  //   //     },
  //   //   });
  // }

  // editar(id:any){
  //   this.obterEventoPorId(id);
  // } 

  // carregarDados(){
  //   setTimeout(() => {
  //     this.agendaForm.get('descricao')?.setValue(this.evento.descricao);
  //     this.agendaForm.get('data')?.setValue(new Date(this.evento.data));
  //   }, 1000);
  // }

  // deletar(id:any){
  //   // if(id != null){
  //   //   this.eventoService.delete(id).subscribe(
  //   //     {
  //   //       next:(res) => {
  //   //         if (res?.success) {
  //   //             this.notificationService.showSuccess('Evento excluído com sucesso!', '');
  //   //             this.listarEventos();
  //   //         }
  //   //       },
  //   //       error: (e) => {
  //   //         this.notificationService.showError("Ocorreu algum erro ao deletar o evento!", "Ops...");
  //   //       },
  //   //     }

  //   //   );
  //   // }
  // }

  

  // autualizarEvento(evento:any){
  //   // const viewModel = {
  //   //   id: this.evento.id,
  //   //   descricao: evento.descricao,
  //   //   data: evento.data
  //   // }

  //   // this.eventoService.update(viewModel).subscribe({
  //   //   next:(res) => {
  //   //     if (res?.success) {
  //   //       this.notificationService.showSuccess('Evento atualizado com sucesso!', '');
  //   //       this.listarEventos();
  //   //     }
  //   //   },
  //   //   error: (e) => {
  //   //     this.notificationService.showError("Ocorreu algum erro ao atualizar o evento!", "Ops...");
  //   //   },
  //   // });
  // }

  limpar(){
    this.agendaForm.reset();
    this.iniciarForm();
  }

}
