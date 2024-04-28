import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  // Construtor
  constructor(private http:HttpClient){ }

  //Método para  retornar o endereço
  ListarProcessos():Observable<Text>{
    return this.http.get<Text>(` 'https://localhost:7055/Processos'`);
  }
}

