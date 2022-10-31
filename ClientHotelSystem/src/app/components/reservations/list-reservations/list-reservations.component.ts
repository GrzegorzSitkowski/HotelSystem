import { Component, OnInit } from '@angular/core';
import { Reservation } from 'src/app/models/reservation.model';
import { ReservationsService } from 'src/app/services/reservations/reservations.service';

@Component({
  selector: 'app-list-reservations',
  templateUrl: './list-reservations.component.html',
  styleUrls: ['./list-reservations.component.css']
})
export class ListReservationsComponent implements OnInit {

  reservations: Reservation[] = [];
  constructor(private reservationsService: ReservationsService) { }

  ngOnInit(): void {
    this.reservationsService.getAllReservations()
    .subscribe({
      next:(reservations) => {
        this.reservations = reservations as Reservation[];
        console.log(this.reservations);
      },
      error: (response) => {
        console.log(response);
      }
    })
  }

}
