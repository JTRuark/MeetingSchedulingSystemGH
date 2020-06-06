namespace MSSProject.Data.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public Availability Availability { get; set; }
        public double Cost { get; set; }
        public int MeetingCount { get; set; }
        public SpecialRoom SpecialRoom { get; set; }
    }
    public enum SpecialRoom
    {
        Yes,
        No
    }
    public enum Availability
    {
        Available,
        Unavailable
    }
}
