using API.Commands;
using Domain;

namespace API.Database
{
    public class FakeDatabase : IDatabase
    {
        private List<Booking> _bookings;
        public FakeDatabase()
        {
            _bookings = new List<Booking>();
        }
        public Booking CreateBooking(Booking booking)
        {
            var newBooking = new Booking(Guid.NewGuid(), booking.Room, booking.ArrivalDate, booking.DepartureDate);
            _bookings.Add(newBooking);

            return newBooking;
        }

        public List<Booking> GetBookings()
        {
            return _bookings;
        }
    }
}
