import { Routes } from '@angular/router';
import { DesempenhoComponent } from './pages/desempenho/desempenho.component';
import { ProcessosComponent } from './pages/processos/processos.component';

export const routes: Routes = [
  {path:"", component: ProcessosComponent}, //processos
  {path:"desempenho", component: DesempenhoComponent}, //desempenho
];
