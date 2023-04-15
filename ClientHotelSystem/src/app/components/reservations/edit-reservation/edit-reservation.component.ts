import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Reservation } from 'src/app/models/reservation.model';
import { GetReservation } from 'src/app/models/reservations/get-reservations.model';
import { ReservationsService } from 'src/app/services/reservations/reservations.service';

@Component({
  selector: 'app-edit-reservation',
  templateUrl: './edit-reservation.component.html',
  styleUrls: ['./edit-reservation.component.css']
})
export class EditReservationComponent implements OnInit {
  reservationDetails: GetReservation = {
    id: '0',
    price: 0,
    mail: '',
    checkIn: '',
    checkOut: '',
    payment: false,
    userId: 0,
    roomId: 0
  };

  constructor(private route: ActivatedRoute, private reservationService: ReservationsService, private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if(id){
          this.reservationService.getReservation(id)
          .subscribe({
            next: (response) => {
              this.reservationDetails = response;
            }
          });
        }
      }
    })
  }

  updateReservation(){
    this.reservationService.updateReservation(this.reservationDetails.id, this.reservationDetails)
    .subscribe({
      next: (response) => {
        this.router.navigate(['reservations']);
      }
    })
  }

  deleteReservation(id: string){
    this.reservationService.deleteReservation(id)
    .subscribe({
      next:(response) => {
        this.router.navigate(['reservations']);
      }
    })
  }
}
