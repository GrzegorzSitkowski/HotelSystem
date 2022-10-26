import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Room } from 'src/app/models/room.model';
import { RoomsService } from 'src/app/services/rooms.service';

@Component({
  selector: 'app-edit-room',
  templateUrl: './edit-room.component.html',
  styleUrls: ['./edit-room.component.css']
})
export class EditRoomComponent implements OnInit {

  roomDetails: Room = {
    id: '',
    name: '',
    capacity: 0,
    price: 0,
    avability: false,
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
            }
          });
        }
      }
    })
  }

  updateRoom(){
    this.roomService.updateRoom(this.roomDetails.id, this.roomDetails)
    .subscribe({
      next: (response) => {
        this.router.navigate(['rooms']);
      }
    });
  }

}
