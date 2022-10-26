import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Room } from '../models/room.model';

@Injectable({
  providedIn: 'root'
})
export class RoomsService {
  
  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http: HttpClient) { }

  getAllRooms(): Observable<Room[]>{
    return this.http.get<Room[]>(this.baseApiUrl + '/api/rooms');
  }

  addRoom(addRoomRequest: Room): Observable<Room>{
    return this.http.post<Room>(this.baseApiUrl + '/api/rooms', addRoomRequest);
  }

  getRoom(id: string): Observable<Room>{
    return this.http.get<Room>(this.baseApiUrl + '/api/rooms/' + id);
  }

  updateRoom(id: string, updateRoomRequest: Room): Observable<Room>{
    return this.http.put<Room>(this.baseApiUrl + '/api/rooms/' + id, updateRoomRequest);
  }
}
