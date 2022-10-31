export interface Reservation{
    id: string;
    price: number;
    mail: string;
    checkIn: Date;
    checkOut: Date;
    payment: boolean;
    userId: number,
    roomId: number
}