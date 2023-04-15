export interface Reservation{
    id: string;
    price: number | null;
    mail: string | null;
    checkIn: Date;
    checkOut: Date;
    payment: boolean;
    userId: number,
    roomId: number | null
}