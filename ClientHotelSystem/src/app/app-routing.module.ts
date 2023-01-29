import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AddReservationComponent } from './components/reservations/add-reservation/add-reservation.component';
import { EditReservationComponent } from './components/reservations/edit-reservation/edit-reservation.component';
import { ListReservationsComponent } from './components/reservations/list-reservations/list-reservations.component';
import { AddRoomComponent } from './components/rooms/add-room/add-room.component';
import { EditRoomComponent } from './components/rooms/edit-room/edit-room.component';
import { RoomsListComponent } from './components/rooms/rooms-list/rooms-list.component';
import { AddUserComponent } from './components/users/add-user/add-user.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'register',
    component: AddUserComponent
  },
  {
    path: 'rooms',
    component: RoomsListComponent
  },
  {
    path: 'rooms/add',
    component: AddRoomComponent
  },
  {
    path: 'rooms/edit/:id',
    component: EditRoomComponent
  },
  {
    path: 'reservations',
    component: ListReservationsComponent
  },
  {
    path: 'reservations/add',
    component: AddReservationComponent
  },
  {
    path: 'reservations/edit/:id',
    component: EditReservationComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
