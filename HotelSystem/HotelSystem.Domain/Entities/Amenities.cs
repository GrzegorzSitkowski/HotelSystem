using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Domain.Entities
{
    public class Amenities
    {
        public int Id { get; set; }
        public bool EntireApartment { get; set; }
        public bool PrivateBathroom { get; set; }
        public bool PrivateKitchenette { get; set; }
        public bool CityView { get; set; }
        public bool AirConditioning { get; set; }
        public bool Patio { get; set; }
        public bool Dishwasher { get; set; }
        public bool Tv { get; set; }
        public bool CoffeeMachine { get; set; }
        public bool WiFi { get; set; }
    }
}
