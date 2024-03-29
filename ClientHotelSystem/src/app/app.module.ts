import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RoomsListComponent } from './components/rooms/rooms-list/rooms-list.component';
import { AddRoomComponent } from './components/rooms/add-room/add-room.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EditRoomComponent } from './components/rooms/edit-room/edit-room.component';
import { ListReservationsComponent } from './components/reservations/list-reservations/list-reservations.component';
import { AddReservationComponent } from './components/reservations/add-reservation/add-reservation.component';
import { EditReservationComponent } from './components/reservations/edit-reservation/edit-reservation.component';
import { HomeComponent } from './components/home/home.component';
import { AddUserComponent } from './components/users/add-user/add-user.component';
import { UsersListComponent } from './components/users/users-list/users-list.component';
import { EditUserComponent } from './components/users/edit-user/edit-user.component';
import { LoginUserComponent } from './components/users/login-user/login-user.component';
import { EditUserByMailComponent } from './components/users/edit-user-by-mail/edit-user-by-mail.component';
import { GetUserComponent } from './components/users/get-user/get-user.component';
import { UsersService } from './services/users/users.service';
import { GetRoomComponent } from './components/rooms/get-room/get-room.component';
import { PreReservationComponent } from './components/reservations/pre-reservation/pre-reservation.component';

@NgModule({
  declarations: [
    AppComponent,
    RoomsListComponent,
    AddRoomComponent,
    EditRoomComponent,
    ListReservationsComponent,
    AddReservationComponent,
    EditReservationComponent,
    HomeComponent,
    AddUserComponent,
    UsersListComponent,
    EditUserComponent,
    LoginUserComponent,
    EditUserByMailComponent,
    GetUserComponent,
    GetRoomComponent,
    PreReservationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [UsersService],
  bootstrap: [AppComponent]
})
export class AppModule { }
