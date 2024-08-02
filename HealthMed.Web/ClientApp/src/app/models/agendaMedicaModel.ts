export class AgendaMedicaModel {
  
  idMedico?: string;
  content?: any[];

  constructor(data: AgendaMedicaModel) {
    if (!data) return;
    Object.assign(this, data);
  }
}
