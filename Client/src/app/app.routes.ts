import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { DesempenhoComponent } from './components/desempenho/desempenho.component';

export const routes: Routes = [
  {path:"", component: AppComponent}, //processos
  {path:"desempenho", component: DesempenhoComponent}, //desempenho
];
