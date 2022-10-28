import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Reservation } from 'src/app/models/reservation.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ReservationsService {
  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http: HttpClient) { }

  getAllReservations(): Observable<Reservation[]>{
    return this.http.get<Reservation[]>(this.baseApiUrl + '/api/reservations');
  }

  addReservation(addReservationRequest: Reservation): Observable<Reservation>{
    return this.http.post<Reservation>(this.baseApiUrl + '/api/reservations', addReservationRequest);
  }
}
