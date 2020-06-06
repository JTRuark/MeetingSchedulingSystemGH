using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSSProject.Data.Models;
using MSSProject.Web.Areas.Core.Data;
using MSSProject.Web.Areas.Identity.Data;
using MSSProject.Web.Data;
using MSSProject.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MSSProject.Web.Areas.Core.Pages.User
{
    public class CreateMeetingModel : DI_BasePageModel
    {
        public CreateMeetingModel(MSSCoreDbContext context,
           IAuthorizationService authorizationService,
           UserManager<MSSWebUser> userManager,
           RoleManager<IdentityRole> roleManager,
           MSSWebAuthContext authContext) : base(context,
                                                         authorizationService,
                                                         userManager,
                                                         roleManager,
                                                         authContext)
        { }
        [BindProperty]
        public Meeting Meeting { get; set; }
        [BindProperty]
        public PaymentInfo Payment { get; set; }
        public IList<PaymentInfo> PaymentList { get; set; }
        public List<PaymentInfo> UserPayList { get; set; } = new List<PaymentInfo>();

        [BindProperty]
        public IList<MSSWebUser> UserList { get; set; }
        [BindProperty]
        public IList<Room> RoomList { get; set; }

        [BindProperty]
        public int SelectedRoom { get; set; }

        [BindProperty]
        public List<Participant> SelectedList { get; set; } = new List<Participant>();

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required]
            public int SelectedRoom { get; set; }
            [Required]
            public DateTime MeetDateTime { get; set; }

            public SpecialRoom SpecialRoom { get; set; }

            public List<Participant> ParticipantList { get; set; }
            public PaymentInfo PaymentMethod { get; set; }
        }
        public async Task<IActionResult> OnGetAsync()
        {
            PaymentList = await Context.Payments
                .AsNoTracking()
                .ToListAsync();
            UserList = await AuthContext.Users
                .AsNoTracking()
                .ToListAsync();
            RoomList = await Context.Rooms
                .AsNoTracking()
                .ToListAsync();

            var user = await UserManager.GetUserAsync(HttpContext.User);

            foreach (var payment in PaymentList)
            {
                if (user.UserName == payment.OwnerId)
                {
                    UserPayList.Add(payment);
                }
            }

            return Page();
        }
        public async Task<IActionResult> OnPostCreateMeetingAsync()
        {
            var user = await UserManager.GetUserAsync(HttpContext.User);
            var room = Context.Rooms.Find(SelectedRoom);

            if (ModelState.IsValid)
            {
                Meeting = new Meeting
                {
                    OwnerId = user.UserName,
                    RoomId = room.RoomId,
                    MeetDateTime = Input.MeetDateTime,
                    SpecialRoom = room.SpecialRoom,
                    //ParticipantList = SelectedList
                };
                await Context.Meetings.AddAsync(Meeting);
                await Context.SaveChangesAsync();
                return Redirect("./Meetings");
            }
            return Page();
        }

    }
}
