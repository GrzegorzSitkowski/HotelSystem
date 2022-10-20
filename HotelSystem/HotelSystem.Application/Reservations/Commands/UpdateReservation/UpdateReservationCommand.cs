using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Application.Reservations.Commands.UpdateReservation
{
    public class UpdateReservationCommand : IRequest
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Mail { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool Payment { get; set; }
    }
}
