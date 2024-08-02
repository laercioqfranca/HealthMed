import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AgendaPacienteService {

  constructor(private http: HttpClient) { }

  create(model: any): Observable<any> {
    return this.http.post('v1/AgendaPaciente/Create', model).pipe(
      map((res: any) => { return res; })
    );
  }

  delete(idAgendaPaciente: any): Observable<any> {
    idAgendaPaciente = '9D814E37-80CD-4524-5B2C-08DCB29F8DBE'
    return this.http.delete(`v1/AgendaPaciente/Delete/${idAgendaPaciente}`).pipe(
      map((res: any) => { return res; })
    );
  }

}
