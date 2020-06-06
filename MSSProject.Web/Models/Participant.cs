using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MSSProject.Web.Models
{
    public class Participant
    {
        [Key]
        public int ListId { get; set; }
        public List<Participant> ParticipantList { get; set; }
    }
}
