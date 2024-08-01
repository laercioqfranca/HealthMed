import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ApiResponseSingle } from '../interfaces/interfaces';

@Injectable()
export class UsuarioService {
  constructor(private http: HttpClient) { }

  getAll(): Observable<any> {
    return this.http.get('v1/Usuario/GetAll').pipe(
      map((response: any) => ({
        data: response.data,
        success: response.success,
      })
    ));
  }

  getAllPerfil(): Observable<any> {
    return this.http.get('v1/PerfilUsuario/GetAll').pipe(
      map((response: any) => ({
        data: response.data,
        success: response.success,
      })
    ));
  }

  getById(id: string): Observable<any> {
    return this.http.get(`v1/Usuario/GetById/${id}`).pipe(
      map((res: any) => { return res; })
    );
  }

  create(model: any): Observable<any> {
    return this.http.post('v1/Usuario/Create', model).pipe(
      map((res: any) => {return res;})
    );
  }

  update(model: any): Observable<any> {
    return this.http.put('v1/Usuario/Update', model).pipe(
      map((res: any) => {return res;})
    );
  }

  delete(id: string): Observable<any> {
    return this.http.delete(`v1/Usuario/Delete/${id}`).pipe(
      map((res: any) => { return res; })
    );
  }

}
