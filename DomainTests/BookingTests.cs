using Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace DomainTests
{
    public class BookingTests
    {
        [Fact]
        public void Booking_Should_Be_Equal_With_Parameters()
        {
            var clientId = Guid.NewGuid();
            var room = new Room("B213");
            var arrivalDate = new DateOnly(2022, 7, 1);
            var departureDate = new DateOnly(2022, 7, 10);

            var booking = new Booking(clientId, room, arrivalDate, departureDate);

            Assert.Equal(clientId, booking.ClientId);
            Assert.Equal(room, booking.Room);
            Assert.Equal(arrivalDate, booking.ArrivalDate);
            Assert.Equal(departureDate, booking.DepartureDate);
        }

        [Fact]
        public void Booking_Should_Throw_Error_If_ArrivalDate_Is_Posterior_Than_DepartureDate()
        {
            var clientId = new Guid();
            var room = new Room("B213");
            var arrivalDate = new DateOnly(2022, 7, 1);
            var departureDate = new DateOnly(2022, 6, 10);

            Assert.Throws<ArgumentException>(() => new Booking(clientId, room, arrivalDate, departureDate));
        }

        public static readonly object[][] OverlapsDates = 
        {
           new object[] { new DateOnly(2022, 6, 20), new DateOnly(2022, 6, 26) },
           new object[] { new DateOnly(2022, 6, 26), new DateOnly(2022, 6, 28) },
           new object[] { new DateOnly(2022, 6, 26), new DateOnly(2022, 6, 30) },
           new object[] { new DateOnly(2022, 6, 20), new DateOnly(2022, 6, 30) }
        };

        [Theory, MemberData(nameof(OverlapsDates))]
        public void Booking_should_Return_False_If_It_Overlaps_for_the_Same_Room(DateOnly arrivalDate, DateOnly departureDate)
        {
            var room = new Room("B213");
            var previousBooking = new Booking(Guid.Empty, room, new DateOnly(2022, 6, 25), new DateOnly(2022, 6, 29));
            var clientId = Guid.Empty;
            var bookings = new List<Booking>() { previousBooking };
            var currentBooking = new Booking(clientId, room, arrivalDate, departureDate);

            Assert.False(currentBooking.CanBook(bookings));
        }

        public static readonly object[][] NoOverlapsDates =
{
           new object[] { new DateOnly(2022, 6, 20), new DateOnly(2022, 6, 24) },
           new object[] { new DateOnly(2022, 6, 20), new DateOnly(2022, 6, 25) },
           new object[] { new DateOnly(2022, 6, 29), new DateOnly(2022, 6, 30) },
           new object[] { new DateOnly(2022, 6, 30), new DateOnly(2022, 7, 1) },
        };

        [Theory, MemberData(nameof(NoOverlapsDates))]
        public void Booking_should_Return_True_If_It_Does_Not_Overlaps_for_the_Same_Room(DateOnly arrivalDate, DateOnly departureDate)
        {
            var room = new Room("B213");
            var previousBooking = new Booking(Guid.Empty, room, new DateOnly(2022, 6, 25), new DateOnly(2022, 6, 29));
            var clientId = Guid.Empty;
            var bookings = new List<Booking>() { previousBooking };
            var currentBooking = new Booking(clientId, room, arrivalDate, departureDate);

            Assert.True(currentBooking.CanBook(bookings));
        }
    }
}
