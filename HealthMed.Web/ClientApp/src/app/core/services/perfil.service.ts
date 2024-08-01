import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PerfilService {

  constructor(private http:HttpClient) { }

  getAll(): Observable<any> {
    return this.http.get('v1/PerfilUsuario/GetAll').pipe(
      map((response: any) => ({
        data: response.data,
        success: response.success,
      })
    ));
  }

}
