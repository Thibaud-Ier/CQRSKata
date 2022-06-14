using Domain;

namespace API.Commands
{
    public class BookingCommand
    {
        public Room Room { get; set; }
        public DateOnly ArrivalDate { get; set; }
        public DateOnly DepartureDate { get; set; }
    }
}
