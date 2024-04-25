import { Component, OnInit } from '@angular/core';
import Chart from 'chart.js/auto'; // Ensure correct import path for Chart.js

@Component({
  selector: 'app-cpu',
  standalone: true,
  imports: [],
  templateUrl: './cpu.component.html',
  styleUrl: './cpu.component.css'
})
export class CpuComponent implements OnInit{
  public chart: any;

  ngOnInit() {
    this.createChart();
  }

  createChart() {
    this.chart = new Chart("MyChart", {
      type: 'line',
      data: {
        labels: ['1','2','3','4','5','6','7','8','8','9','10'],
        datasets: [
          // {
          //   label: "Sales",
          //   data: [467, 576, 572, 79, 92, 574, 573, 576, 576, 572,], // Removed quotes to treat as numbers
          //   backgroundColor: 'blue'
          // },
          {
            label: "CPU",
            data: [542, 542, 536, 327, 17, 0.00, 538, 541, 576,100, 572], // Removed quotes to treat as numbers
            backgroundColor: 'limegreen'
          }
        ]
      },
      options: {
        aspectRatio: 2.5
      }
    });
  }
}
