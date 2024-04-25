import { Component } from '@angular/core';
import { SideBarComponent } from '../side-bar/side-bar.component';
import { NavbarComponent } from '../navbar/navbar.component';
import { ActionBarComponent } from '../action-bar/action-bar.component';

@Component({
  selector: 'app-processos',
  standalone: true,
  imports: [SideBarComponent,NavbarComponent,ActionBarComponent],
  templateUrl: './processos.component.html',
  styleUrl: './processos.component.css'
})
export class ProcessosComponent {

}
