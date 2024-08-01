export class AgendaMedicaFiltroModel {
  
  data?: string;
  idHorario?: string;
  idMedico?: string;
  idPaciente?: string;

  constructor(data: any) {
    if (!data) return;
    Object.assign(this, data);
  }
}
