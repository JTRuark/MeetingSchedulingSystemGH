using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MSSProject.Web.Migrations.MSSCoreDb
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    CompId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorId = table.Column<string>(nullable: true),
                    CreatorName = table.Column<string>(nullable: true),
                    CreatorEmail = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ComplaintText = table.Column<string>(nullable: true),
                    Response = table.Column<string>(nullable: true),
                    AdminStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.CompId);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    MeetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<string>(nullable: true),
                    RoomId = table.Column<int>(nullable: false),
                    MeetDateTime = table.Column<DateTime>(nullable: false),
                    SpecialRoom = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.MeetId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PayId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CardNumber = table.Column<string>(nullable: true),
                    CardType = table.Column<string>(nullable: true),
                    Cvv = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    BillingZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PayId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(nullable: true),
                    Availability = table.Column<int>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    MeetingCount = table.Column<int>(nullable: false),
                    SpecialRoom = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    ListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingMeetId = table.Column<int>(nullable: true),
                    ParticipantListId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.ListId);
                    table.ForeignKey(
                        name: "FK_Participant_Meetings_MeetingMeetId",
                        column: x => x.MeetingMeetId,
                        principalTable: "Meetings",
                        principalColumn: "MeetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Participant_Participant_ParticipantListId",
                        column: x => x.ParticipantListId,
                        principalTable: "Participant",
                        principalColumn: "ListId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Complaints",
                columns: new[] { "CompId", "AdminStatus", "ComplaintText", "CreatorEmail", "CreatorId", "CreatorName", "DateCreated", "Response" },
                values: new object[,]
                {
                    { 3, 0, "It works! It finally works!", "bjohnson@pennstatesoft.com", null, "Bob Johnson", new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Local), "Its about damn time!" },
                    { 1, 1, "The service here sucks, I dont know why I come here. Can I speak to your manager?", "dsmith@pennstatesoft.com", null, "Dave Smith", new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Local), null },
                    { 2, 1, "Justin is a really awesome admin, that Doug guy is not...fire him.", "tsawyer@pennstatesoft.com", null, "Tom Sawyer", new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Local), null }
                });

            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "MeetId", "MeetDateTime", "OwnerId", "RoomId", "SpecialRoom" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), "dsmith", 8, 1 },
                    { 2, new DateTime(2020, 6, 5, 13, 30, 0, 0, DateTimeKind.Unspecified), "bjohnson", 5, 0 }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "BillingZipCode", "CardNumber", "CardType", "Cvv", "ExpirationDate", "FirstName", "LastName", "OwnerId" },
                values: new object[,]
                {
                    { 1, "12345", "1234567891234567", "Mastercard", "123", new DateTime(2021, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom", "Sawyer", "tsawyer" },
                    { 2, "67890", "9123456789123456", "Visa", "456", new DateTime(2022, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob", "Johnson", "bjohnson" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Availability", "Cost", "MeetingCount", "RoomName", "SpecialRoom" },
                values: new object[,]
                {
                    { 8, 0, 50.0, 0, "Detroit", 1 },
                    { 7, 0, 50.0, 0, "Escape", 1 },
                    { 6, 0, 50.0, 0, "New York", 1 },
                    { 5, 0, 50.0, 0, "Champaigne", 0 },
                    { 2, 0, 50.0, 0, "Chicago", 1 },
                    { 3, 0, 50.0, 0, "Las Vegas", 1 },
                    { 9, 0, 100.0, 0, "Missing", 1 },
                    { 1, 0, 50.0, 0, "Green", 1 },
                    { 4, 0, 50.0, 0, "Red", 0 },
                    { 10, 0, 100.0, 0, "Double", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participant_MeetingMeetId",
                table: "Participant",
                column: "MeetingMeetId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_ParticipantListId",
                table: "Participant",
                column: "ParticipantListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Meetings");
        }
    }
}
