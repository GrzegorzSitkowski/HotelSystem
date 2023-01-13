import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Room } from 'src/app/models/room.model';
import { RoomsService } from 'src/app/services/rooms.service';

@Component({
  selector: 'app-add-room',
  templateUrl: './add-room.component.html',
  styleUrls: ['./add-room.component.css']
})
export class AddRoomComponent implements OnInit {

  addRoomRequest: Room = {
    id: '0',
    name: '',
    capacity: 0,
    price: 0,
    avability: false,
    amenities: '',
    description: ''
  }
  constructor(private roomService: RoomsService, private router: Router) { }

  ngOnInit(): void {
  }

  addRoom(){
    console.log(this.addRoomRequest);
    this.roomService.addRoom(this.addRoomRequest)
    .subscribe({
      next: (room) => {
        this.router.navigate(['rooms']);
        console.log(room);
      }
    });
  }
  }
