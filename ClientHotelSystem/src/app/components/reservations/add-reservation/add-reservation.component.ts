import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Reservation } from 'src/app/models/reservation.model';
import { ReservationsService } from 'src/app/services/reservations/reservations.service';

@Component({
  selector: 'app-add-reservation',
  templateUrl: './add-reservation.component.html',
  styleUrls: ['./add-reservation.component.css']
})
export class AddReservationComponent implements OnInit {
  addReservationRequest: Reservation = {
    id: '0',
    price: 0,
    mail: '',
    checkIn: new Date(),
    checkOut: new Date(),
    payment: false,
    userId: 0,
    roomId: 0
   }
  constructor(private reservationService: ReservationsService, private router: Router) { }

  ngOnInit(): void {
  }

  addReservation(){
    console.log(this.addReservationRequest);
    this.reservationService.addReservation(this.addReservationRequest)
    .subscribe({
      next: (reservation) => {
        this.router.navigate(['reservations']);
        console.log(reservation);
      }
    })
  }

}
