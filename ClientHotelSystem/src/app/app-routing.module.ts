import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RoomsListComponent } from './components/rooms/rooms-list/rooms-list.component';

const routes: Routes = [
  {
    path: '',
    component: RoomsListComponent
  },
  {
    path: 'rooms',
    component: RoomsListComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
