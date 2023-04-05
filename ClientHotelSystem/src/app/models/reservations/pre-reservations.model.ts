export interface PreReservation{
    checkIn: Date;
    checkOut: Date;
    roomName: string | null;
    roomId: string | null;
    price: number | null;  
}