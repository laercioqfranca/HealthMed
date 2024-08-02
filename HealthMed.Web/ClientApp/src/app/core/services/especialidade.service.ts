import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EspecialidadeService {

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get('v1/Especialidade/GetAll').pipe(
      map((response: any) => ({
        data: response.data,
        success: response.success,
      })
    ));
  }

}
