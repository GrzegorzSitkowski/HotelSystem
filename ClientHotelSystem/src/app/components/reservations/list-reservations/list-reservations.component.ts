import { Component, OnInit } from '@angular/core';
import { Reservation } from 'src/app/models/reservation.model';

@Component({
  selector: 'app-list-reservations',
  templateUrl: './list-reservations.component.html',
  styleUrls: ['./list-reservations.component.css']
})
export class ListReservationsComponent implements OnInit {

  reservations: Reservation[] = [];
  constructor() { }

  ngOnInit(): void {
  }

}
