import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';


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

        console.log(this.ListarProcessos())

  }

  r = "";

  async ListarProcessos(){

    const request = await fetch('https://localhost:7231/process', {
      method: 'GET',
      headers: {
        'accept': '*/*'
      }
    });

    const show = await request.json();

    return show

  }
}
