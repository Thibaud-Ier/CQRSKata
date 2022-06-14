using API.Commands;
using Domain;

namespace API.Database
{
    public interface IDatabase
    {
        Booking CreateBooking(Booking booking);
        List<Booking> GetBookings();
    }
}
