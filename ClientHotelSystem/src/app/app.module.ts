import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RoomsListComponent } from './components/rooms/rooms-list/rooms-list.component';
import { AddRoomComponent } from './components/rooms/add-room/add-room.component';
import { FormsModule } from '@angular/forms';
import { EditRoomComponent } from './components/rooms/edit-room/edit-room.component';
import { ListReservationsComponent } from './components/reservations/list-reservations/list-reservations.component';
import { AddReservationComponent } from './components/reservations/add-reservation/add-reservation.component';
import { EditReservationComponent } from './components/reservations/edit-reservation/edit-reservation.component';

@NgModule({
  declarations: [
    AppComponent,
    RoomsListComponent,
    AddRoomComponent,
    EditRoomComponent,
    ListReservationsComponent,
    AddReservationComponent,
    EditReservationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
