import { Component, OnInit } from '@angular/core';
import { Room } from 'src/app/models/room.model';
import { RoomsService } from 'src/app/services/rooms.service';

@Component({
  selector: 'app-rooms-list',
  templateUrl: './rooms-list.component.html',
  styleUrls: ['./rooms-list.component.css']
})
export class RoomsListComponent implements OnInit {

  rooms: Room[] = [];
  constructor(private roomsService: RoomsService) { }

  ngOnInit(): void {
    this.roomsService.getAllRooms()
    .subscribe({
      next: (rooms) => {
        this.rooms = rooms as Room[];
        console.log(this.rooms);
      },
      error: (response) => {
        console.log(response);
      }
    })
  }

}
