import { Component, OnInit } from '@angular/core';
import { CpuComponent } from '../../components/charts/cpu/cpu.component';
import { SideBarComponent } from '../../components/bars/side-bar/side-bar.component';

@Component({
  selector: 'app-desempenho',
  standalone:true,
  imports:[CpuComponent,SideBarComponent],
  templateUrl: './desempenho.component.html',
  styleUrls: ['./desempenho.component.css']
})
export class DesempenhoComponent {

}
