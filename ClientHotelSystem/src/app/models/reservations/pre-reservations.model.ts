export interface PreReservation{
    checkIn: Date | null;
    checkOut: Date | null;
    lengthStay: number;
    roomName: string | null;
    roomId: string | null;
    price: number | null;  
}