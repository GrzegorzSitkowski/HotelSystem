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
import { EditUserByMailComponent } from './components/users/edit-user-by-mail/edit-user-by-mail.component';
import { EditUserComponent } from './components/users/edit-user/edit-user.component';
import { GetUserComponent } from './components/users/get-user/get-user.component';
import { LoginUserComponent } from './components/users/login-user/login-user.component';
import { UsersListComponent } from './components/users/users-list/users-list.component';
import { AuthGuard } from './services/users/auth.guard';
import { GetRoomComponent } from './components/rooms/get-room/get-room.component';
import { PreReservationComponent } from './components/reservations/pre-reservation/pre-reservation.component';
const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'users',
    component: UsersListComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'users/login',
    component: LoginUserComponent
  },
  {
    path: 'users/add',
    component: AddUserComponent
  },
  {
    path: 'users/edit/:id',
    component: EditUserComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'users/edit/:mail',
    component: EditUserByMailComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'users/get/:mail',
    component: GetUserComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'rooms',
    component: RoomsListComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'rooms/add',
    component: AddRoomComponent,
    canActivate: [AuthGuard]
  },
  {
    path:'rooms/get/:id',
    component: GetRoomComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'rooms/edit/:id',
    component: EditRoomComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'reservations',
    component: ListReservationsComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'rooms/get/:id/reservations/check',
    component: PreReservationComponent
  },
  {
    path: 'reservations/add',
    component: AddReservationComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'rooms/get/:id/reservations/check/reservations/add',
    component: AddReservationComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'reservations/edit/:id',
    component: EditReservationComponent,
    canActivate: [AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
