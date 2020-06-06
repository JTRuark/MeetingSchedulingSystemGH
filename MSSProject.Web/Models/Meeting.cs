using MSSProject.Web.Models;
using System;
using System.Collections.Generic;

namespace MSSProject.Data.Models
{
    public class Meeting
    {
        public int MeetId { get; set; }
        public string OwnerId { get; set; }
        //this is the UserId from AspNetUser table (Identity)
        public int RoomId { get; set; }
        public DateTime MeetDateTime { get; set; }
        public List<Participant> ParticipantList { get; set; }
        public SpecialRoom SpecialRoom { get; set; }
    }
}
