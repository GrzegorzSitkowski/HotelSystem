export interface GetReservation{
    id: string;
    price: number | null;
    mail: string | null;
    checkIn: string;
    checkOut: string;
    payment: boolean;
    userId: number,
    roomId: number | null
}