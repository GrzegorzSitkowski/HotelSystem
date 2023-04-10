export interface PreReservation{
    checkIn: Date | null;
    checkOut: Date | null;
    lengthStay: number | null;
    roomName: string | null;
    roomId: string | null;
    price: number | null;  
}