import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
//import {fetch} from 'node-fetch';

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
  templateUrl: './table.component.html',
  styleUrl: './table.component.css'
})
export class TableComponent implements OnInit{
constructor(private http: HttpClient){

}

ngOnInit(): void {
    this.fetchDetails();
}

public fetchDetails(){
  this.http.get('https://jsonplaceholder.typicode.com/todos/1').subscribe(
    (resp:any) => {
      console.log(resp)
    }
  )
}
}





