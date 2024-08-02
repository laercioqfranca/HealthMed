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

}
