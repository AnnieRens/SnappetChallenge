import {Component, OnInit, ViewChild} from '@angular/core';

import { Chart } from 'chart.js';
import * as moment from 'moment';
import {ClassProgressItem} from '../models/class-progress-item.model';
import {ClassWorkProgressService} from '../services/class-work-progress.service';

@Component({
  selector: 'app-class-work-progress',
  templateUrl: './class-work-progress.component.html',
  styleUrls: ['./class-work-progress.component.css']
})
export class ClassWorkProgressComponent implements OnInit {

  @ViewChild('lineChart', {static: true}) private chartRef;
  public chart: any;
  public chartData: any;
  public chartLoading = true;

  public classProgressItems: ClassProgressItem[];

  public error = undefined;

  constructor(private studentWorkStatService: ClassWorkProgressService) { }

  ngOnInit() {
    this.initialize();
  }

  initialize() {
    let startDate = moment("20150224", "YYYYMMDD").startOf('day');
    let endDate = moment("20150324", "YYYYMMDD").endOf('day');

    this.studentWorkStatService.getStudentStatistic(startDate.toISOString(), endDate.toISOString()).subscribe(res => {
      this.classProgressItems = res;
      this.chartLoading = false;

      this.chartData = this.classProgressItems.map(v => ({x: v.date, y: v.value}));

      this.drawChart();
    }
  );
  }

  drawChart() {

    let labels = this.chartData.map(pair => moment(pair.x).format('MMMM Do YYYY'));

    this.chart = new Chart(this.chartRef.nativeElement, {
      type: 'line',
      data: {
        labels: labels,
        datasets: [
          {
            data: this.chartData,
            borderColor: '#00AEFF',
            fill: false
          }
        ]
      },
      options: {
        legend: {
          display: false
        },
        scales: {
          xAxes: [{
            display: true
          }],
          yAxes: [{
            display: true
          }],
        }
      }
    });
  }
}
