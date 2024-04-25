import { Component } from '@angular/core';
import { SideBarComponent } from '../../components/bars/side-bar/side-bar.component';
import { NavbarComponent } from '../../components/bars/navbar/navbar.component';
import { ActionBarComponent } from '../../components/bars/action-bar/action-bar.component';

@Component({
  selector: 'app-processos',
  standalone: true,
  imports: [SideBarComponent,NavbarComponent,ActionBarComponent],
  templateUrl: './processos.component.html',
  styleUrl: './processos.component.css'
})
export class ProcessosComponent {

}
