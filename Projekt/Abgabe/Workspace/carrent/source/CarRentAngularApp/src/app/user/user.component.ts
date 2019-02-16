import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
  
  columnDefs = [
    {headerName: 'Marke', field: 'marke', sortable: true, filter: true },
    {headerName: 'Seriennummer', field: 'seriennummer', sortable: true, filter: true },
    {headerName: 'Typ', field: 'typ', sortable: true, filter: true},
    {headerName: 'Farbe', field: 'farbe', sortable: true, filter: true},
    {headerName: 'Auswahl', field: 'Auswahl', checkboxSelection: true}
  ];

  rowData = [
    { marke: 'Toyota', seriennummer: '125498ee', typ: 'Sport', farbe: 'Blau' },
    { marke: 'Porsche', seriennummer: '2168ME157', typ: 'Luxus', farbe: 'Schwarz' },
    { marke: 'Toyota', seriennummer: '12387UUWEW', typ: 'Sport', farbe: "Gruen" },
  ];
}
