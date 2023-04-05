import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Room } from 'src/app/models/room.model';
import { RoomsService } from 'src/app/services/rooms.service';

@Component({
  selector: 'app-get-room',
  templateUrl: './get-room.component.html',
  styleUrls: ['./get-room.component.css']
})
export class GetRoomComponent implements OnInit {

  roomDetails: Room = {
    id: '',
    name: '',
    capacity: 0,
    price: 0,
    avability: false,
    amenities: '',
    photoUrl: '',
    description: ''
  };

  constructor(private route: ActivatedRoute, private roomService: RoomsService, private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if(id){
          this.roomService.getRoom(id)
          .subscribe({
            next: (response) => {
              this.roomDetails = response;
              localStorage.setItem("id", response.id);
              localStorage.setItem("roomName", response.name);
              localStorage.setItem("price", response.price.toString());
            }

          });
        }
      }
    })
  }
}
