using System;

namespace MSSProject.Data.Models
{
    public class PaymentInfo
    {
        public int PayId { get; set; }
        public string OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public string Cvv { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string BillingZipCode { get; set; }
    }
}
