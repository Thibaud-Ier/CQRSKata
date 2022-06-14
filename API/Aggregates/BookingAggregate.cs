using API.Commands;
using API.Database;
using Domain;

namespace API.Aggregates
{
    public class BookingAggregate
    {
        private IDatabase _database;

        public BookingAggregate(IDatabase database)
        {
            _database = database;
        }

        public Booking HandleBookingCommand(BookingCommand booking)
        {
            var bookings = new List<Booking>();
            var newBooking = new Booking(Guid.Empty, booking.Room, booking.ArrivalDate, booking.DepartureDate);

            return _database.CreateBooking(newBooking);
        }
    }
}
