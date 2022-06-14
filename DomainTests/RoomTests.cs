using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DomainTests
{
    public class RoomTests
    {
        [Fact]
        public void Room_Should_Be_Equal_With_Parameters()
        {
            var roomName = "B103";
            Room room = new Room(roomName);

            Assert.Equal(roomName, room.RoomName);

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Booking_RoomName_Should_Throw_Error_If_Null_Or_Empty(string roomName)
        {
            Assert.Throws<ArgumentException>(() => new Room(roomName));
        }
    }
}
