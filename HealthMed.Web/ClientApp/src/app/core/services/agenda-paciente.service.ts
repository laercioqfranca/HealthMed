import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AgendaPacienteService {

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get('v1/AgendaPaciente/GetAll').pipe(
      map((response: any) => ({
        data: response.data,
        success: response.success,
      })
    ));
  }

  create(model: any): Observable<any> {
    return this.http.post('v1/AgendaPaciente/Create', model).pipe(
      map((res: any) => { return res; })
    );
  }

  delete(idAgendaPaciente: any): Observable<any> {
    return this.http.delete(`v1/AgendaPaciente/Delete/${idAgendaPaciente}`).pipe(
      map((res: any) => { return res; })
    );
  }

}
