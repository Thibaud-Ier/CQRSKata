using System.Diagnostics.CodeAnalysis;

namespace Domain
{
    public struct Room
    {
        public string RoomName { get; }

        public Room(string roomName)
        {
            if (string.IsNullOrEmpty(roomName))
                throw new ArgumentException("Room should not be null or empty");

            RoomName = roomName;
        }

        public static bool operator ==(Room r1, Room r2)
        {
            return r1.Equals(r2);
        }

        public static bool operator !=(Room r1, Room r2)
        {
            return !r1.Equals(r2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Room room)
                return RoomName == room.RoomName;

            return false;
        }
    }
}
