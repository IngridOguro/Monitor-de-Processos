import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './components/bars/navbar/navbar.component';
import { ActionBarComponent } from './components/bars/action-bar/action-bar.component';
import { SideBarComponent } from './components/bars/side-bar/side-bar.component';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,NavbarComponent, CommonModule,ActionBarComponent,SideBarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  parentVariable: string = 'Hello from Parent';
}
