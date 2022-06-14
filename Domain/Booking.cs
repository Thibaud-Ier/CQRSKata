using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public struct Booking
    {
        public Guid ClientId { get; }

        public Room Room { get; }

        public DateOnly ArrivalDate { get; }

        public DateOnly DepartureDate { get; }

        public Booking(Guid clientId, Room room, DateOnly arrivalDate, DateOnly departureDate)
        {
            if (arrivalDate > departureDate)
                throw new ArgumentException("Arrival Date is posterior than Departure Date");

            ClientId = clientId;
            Room = room;
            ArrivalDate = arrivalDate;
            DepartureDate = departureDate;
        }

        public bool CanBook(List<Booking> bookings)
        {
            var current = this;
            return bookings.All(x => current.Room != x.Room ||
                current.ArrivalDate >= x.DepartureDate || current.DepartureDate <= x.ArrivalDate);
        }
    }
}
