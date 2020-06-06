using System;
using System.ComponentModel.DataAnnotations;

namespace MSSProject.Data.Models
{
    public class Complaint
    {
        [Key]
        public int CompId { get; set; }
        public string CreatorId { get; set; }
        public string CreatorName { get; set; }
        public string CreatorEmail { get; set; }
        public DateTime DateCreated { get; set; }
        public string ComplaintText { get; set; }
        public string Response { get; set; }
        public ComplaintStatus AdminStatus { get; set; }
    }
    public enum ComplaintStatus
    {
        ResponseCompleted,
        Incomplete
    }
}
