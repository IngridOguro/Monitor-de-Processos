import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
//import {fetch} from 'node-fetch';

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './table.component.html',
  styleUrl: './table.component.css'
})
export class TableComponent {


  // AUTENTICAR
  mensagem:string="";
  autenticar():void{

        console.log(this.ListarProcessos());

  }

ListarProcessos(){
  async function fazerRequisicao() {
    const url = 'https://localhost:7055/Processos';
    const options = {
      method: 'GET',
      headers: {
        'Accept': 'text/plain'
      }
    };

    try {
      const resposta = await fetch(url, options);
      const texto = await resposta.json();
      console.log('Resposta:', texto);
    } catch (erro) {
      console.error('Erro ao fazer requisição:', erro);
    }
  }

  fazerRequisicao();

}
}
