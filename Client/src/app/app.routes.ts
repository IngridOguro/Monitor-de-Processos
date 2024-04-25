import { Routes } from '@angular/router';
import { DesempenhoComponent } from './components/desempenho/desempenho.component';
import { ProcessosComponent } from './components/processos/processos.component';

export const routes: Routes = [
  {path:"", component: ProcessosComponent}, //processos
  {path:"desempenho", component: DesempenhoComponent}, //desempenho
];
