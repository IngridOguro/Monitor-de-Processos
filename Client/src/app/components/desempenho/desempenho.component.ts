import { Component, OnInit } from '@angular/core';
import Chart from 'chart.js/auto'; // Ensure correct import path for Chart.js

@Component({
  selector: 'app-desempenho',
  templateUrl: './desempenho.component.html',
  styleUrls: ['./desempenho.component.css']
})
export class DesempenhoComponent implements OnInit {
  public chart: any;

  ngOnInit() {
    this.createChart();
  }

  createChart() {
    this.chart = new Chart("MyChart", {
      type: 'bar',
      data: {
        labels: ['2022-05-10', '2022-05-11', '2022-05-12', '2022-05-13', '2022-05-14', '2022-05-15', '2022-05-16', '2022-05-17'],
        datasets: [
          {
            label: "Sales",
            data: [467, 576, 572, 79, 92, 574, 573, 576], // Removed quotes to treat as numbers
            backgroundColor: 'blue'
          },
          {
            label: "Profit",
            data: [542, 542, 536, 327, 17, 0.00, 538, 541], // Removed quotes to treat as numbers
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
