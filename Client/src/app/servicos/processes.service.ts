import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Processos } from '../modelos/Processo';
@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http:HttpClient){ }

  private urlProcesso:string = 'https://localhost:7055/Processos';

  listarProcessos():Observable<Processos[]>{
    return this.http.get<Processos[]>(this.urlProcesso);
  }
}
