import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PreReservation } from 'src/app/models/reservations/pre-reservations.model';

@Component({
  selector: 'app-pre-reservation',
  templateUrl: './pre-reservation.component.html',
  styleUrls: ['./pre-reservation.component.css']
})



export class PreReservationComponent implements OnInit {

  preReservation: PreReservation ={
    checkIn: new Date(),
    checkOut: new Date(),
    lengthStay: 0,
    roomName: '',
    roomId: '',
    price: 0
  }

  constructor(private router: Router) {  }

  ngOnInit(): void {  
    this.preReservation.roomName = localStorage.getItem("roomName");
    this.preReservation.roomId = localStorage.getItem("id");
    this.preReservation.price = Number(localStorage.getItem("price"));
  }

  checkingReservation(){
    localStorage.setItem("lengthStay", this.preReservation.lengthStay?.toString());
  }

}
