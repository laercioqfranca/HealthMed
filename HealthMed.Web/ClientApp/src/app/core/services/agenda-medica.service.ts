import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { AgendaMedicaModel } from '../../models/agendaMedicaModel';

@Injectable({
  providedIn: 'root'
})
export class AgendaMedicaService {

  constructor(private http:HttpClient) { }

  getByFilter(filtro:any): Observable<any> {
    return this.http.get('v1/AgendaMedica/GetByFilter', {params:filtro}).pipe(
      map((response: any) => ({
        data: response.data,
        success: response.success,
      })
    ));
  }

  getByIdMedico(idMedico: any): Observable<any> {
    return this.http.get(`v1/AgendaMedica/GetListByIdMedico/${idMedico}`).pipe(
      map((res: any) => { return res; })
    );
  }

  create(model: AgendaMedicaModel): Observable<any> {
    return this.http.post('v1/AgendaMedica/Create', model).pipe(
      map((res: any) => {return res;})
    );
  }

  deletePorData(dataAgenda: any): Observable<any> {
    let partes = dataAgenda.split('/');
    let dataFormatada = `${partes[2]}-${partes[1]}-${partes[0]}`; // retorna o formato DD/MM/AAAA para AAAA-MM-DD

    return this.http.delete(`v1/AgendaMedica/DeletePorData/${dataFormatada}`).pipe(
      map((res: any) => { return res; })
    );
  }

  deleteAgenda(idAgenda: any): Observable<any> {
    return this.http.delete(`v1/AgendaMedica/Delete/${idAgenda}`).pipe(
      map((res: any) => { return res; })
    );
  }

}
