import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../servicos/processes.service';
import { Processos } from '../../modelos/Processo';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './table.component.html',
  styleUrl: './table.component.css'
})
export class TableComponent {

constructor(private servicoProcesso:ApiService){}

process:Processos[] = [];
data:any;

ngOnInit(){
  this.listarProcessos();
}

listarProcessos():void {
  this.servicoProcesso.listarProcessos()
  .subscribe(retorno => {
    console.table(retorno);
    this.process = retorno;
   })
}

}





