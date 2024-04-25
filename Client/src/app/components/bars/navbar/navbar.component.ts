import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule ],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  //pesquisa
  formulario = new FormGroup({
    processo: new FormControl()
});
childVariable: string = "";
pesquisar():void{
  const process_name = this.formulario.value.processo;
  let childVariable = this.formulario.value.processo;
}
}
