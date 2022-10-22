import { Component, OnInit } from '@angular/core';
import { Room } from 'src/app/models/room.model';

@Component({
  selector: 'app-rooms-list',
  templateUrl: './rooms-list.component.html',
  styleUrls: ['./rooms-list.component.css']
})
export class RoomsListComponent implements OnInit {

  rooms: Room[] = [];
  constructor() { }

  ngOnInit(): void {
    this.rooms.push();
  }

}
