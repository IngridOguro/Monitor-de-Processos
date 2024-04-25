import { Component} from '@angular/core';
import { CpuComponent } from '../../components/charts/cpu/cpu.component';
import { SideBarComponent } from '../../components/bars/side-bar/side-bar.component';
import { NetComponent } from '../../components/charts/net/net.component';
import { DiscComponent } from '../../components/charts/disc/disc.component';
import { MemoryComponent } from '../../components/charts/memory/memory.component';

@Component({
  selector: 'app-desempenho',
  standalone:true,
  imports:[CpuComponent,NetComponent,DiscComponent,MemoryComponent,SideBarComponent],
  templateUrl: './desempenho.component.html',
  styleUrls: ['./desempenho.component.css']
})
export class DesempenhoComponent {

}
