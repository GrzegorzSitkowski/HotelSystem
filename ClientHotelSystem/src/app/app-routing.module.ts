import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddRoomComponent } from './components/rooms/add-room/add-room.component';
import { RoomsListComponent } from './components/rooms/rooms-list/rooms-list.component';

const routes: Routes = [
  {
    path: '',
    component: RoomsListComponent
  },
  {
    path: 'rooms',
    component: RoomsListComponent
  },
  {
    path: 'rooms/add',
    component: AddRoomComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
