using Microsoft.EntityFrameworkCore;
using MSSProject.Data.Models;
using System;

namespace MSSProject.Web.Areas.Core.Data
{
    public class MSSCoreDbContext : DbContext
    {
        public MSSCoreDbContext(DbContextOptions<MSSCoreDbContext> options) : base(options) { }

        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<PaymentInfo> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Room>().HasKey(r => r.RoomId);
            builder.Entity<Room>().HasData(new Room
            {
                RoomId = 1,
                RoomName = "Green",
                SpecialRoom = SpecialRoom.No,
                Availability = Availability.Available,
                Cost = 50,
                MeetingCount = 0,
            });
            builder.Entity<Room>().HasData(new Room
            {
                RoomId = 2,
                RoomName = "Chicago",
                SpecialRoom = SpecialRoom.No,
                Availability = Availability.Available,
                Cost = 50,
                MeetingCount = 0
            });
            builder.Entity<Room>().HasData(new Room
            {
                RoomId = 3,
                RoomName = "Las Vegas",
                SpecialRoom = SpecialRoom.No,
                Availability = Availability.Available,
                Cost = 50,
                MeetingCount = 0
            });
            builder.Entity<Room>().HasData(new Room
            {
                RoomId = 4,
                RoomName = "Red",
                SpecialRoom = SpecialRoom.Yes,
                Availability = Availability.Available,
                Cost = 50,
                MeetingCount = 0
            });
            builder.Entity<Room>().HasData(new Room
            {
                RoomId = 5,
                RoomName = "Champaigne",
                SpecialRoom = SpecialRoom.Yes,
                Availability = Availability.Available,
                Cost = 50,
                MeetingCount = 0
            });
            builder.Entity<Room>().HasData(new Room
            {
                RoomId = 6,
                RoomName = "New York",
                SpecialRoom = SpecialRoom.No,
                Availability = Availability.Available,
                Cost = 50,
                MeetingCount = 0
            });
            builder.Entity<Room>().HasData(new Room
            {
                RoomId = 7,
                RoomName = "Escape",
                SpecialRoom = SpecialRoom.No,
                Availability = Availability.Available,
                Cost = 50,
                MeetingCount = 0
            });
            builder.Entity<Room>().HasData(new Room
            {
                RoomId = 8,
                RoomName = "Detroit",
                SpecialRoom = SpecialRoom.No,
                Availability = Availability.Available,
                Cost = 50,
                MeetingCount = 0
            });
            builder.Entity<Room>().HasData(new Room
            {
                RoomId = 9,
                RoomName = "Missing",
                SpecialRoom = SpecialRoom.No,
                Availability = Availability.Available,
                Cost = 100,
                MeetingCount = 0
            });
            builder.Entity<Room>().HasData(new Room
            {
                RoomId = 10,
                RoomName = "Double",
                SpecialRoom = SpecialRoom.No,
                Availability = Availability.Available,
                Cost = 100,
                MeetingCount = 0
            });
            builder.Entity<Meeting>().HasKey(m => m.MeetId);
            builder.Entity<Meeting>().HasData(new Meeting
            {
                MeetId = 1,
                OwnerId = "dsmith",
                RoomId = 8,
                MeetDateTime = new DateTime(2020, 6, 15, 12, 00, 0),
                SpecialRoom = SpecialRoom.No
            });
            builder.Entity<Meeting>().HasData(new Meeting
            {
                MeetId = 2,
                OwnerId = "bjohnson",
                RoomId = 5,
                MeetDateTime = new DateTime(2020, 6, 5, 13, 30, 0),
                SpecialRoom = SpecialRoom.Yes
            });
            builder.Entity<PaymentInfo>().HasKey(p => p.PayId);
            builder.Entity<PaymentInfo>().HasData(new PaymentInfo
            {
                PayId = 1,
                FirstName = "Tom",
                LastName = "Sawyer",
                OwnerId = "tsawyer",
                CardNumber = "1234567891234567",
                CardType = "Mastercard",
                Cvv = "123",
                ExpirationDate = new DateTime(2021, 4, 20),
                BillingZipCode = "12345"
            });
            builder.Entity<PaymentInfo>().HasData(new PaymentInfo
            {
                PayId = 2,
                FirstName = "Bob",
                LastName = "Johnson",
                OwnerId = "bjohnson",
                CardNumber = "9123456789123456",
                CardType = "Visa",
                Cvv = "456",
                ExpirationDate = new DateTime(2022, 8, 13),
                BillingZipCode = "67890"
            });

            builder.Entity<Complaint>().HasKey(c => c.CompId);
            builder.Entity<Complaint>().HasData(new Complaint
            {
                CompId = 3,
                CreatorId = null,
                CreatorName = "Bob Johnson",
                CreatorEmail = "bjohnson@pennstatesoft.com",
                DateCreated = DateTime.Today,
                ComplaintText = "It works! It finally works!",
                Response = "Its about damn time!",
                AdminStatus = ComplaintStatus.ResponseCompleted
            });
            builder.Entity<Complaint>().HasData(new Complaint
            {
                CompId = 1,
                CreatorId = null,
                CreatorName = "Dave Smith",
                CreatorEmail = "dsmith@pennstatesoft.com",
                DateCreated = DateTime.Today,
                ComplaintText = "The service here sucks, " +
                                "I dont know why I come here. " +
                                "Can I speak to your manager?",
                Response = null,
                AdminStatus = ComplaintStatus.Incomplete
            });
            builder.Entity<Complaint>().HasData(new Complaint
            {
                CompId = 2,
                CreatorId = null,
                CreatorName = "Tom Sawyer",
                CreatorEmail = "tsawyer@pennstatesoft.com",
                DateCreated = DateTime.Today,
                ComplaintText = "Justin is a really awesome admin, " +
                                "that Doug guy is not...fire him.",
                Response = null,
                AdminStatus = ComplaintStatus.Incomplete
            });

        }
    }

}
