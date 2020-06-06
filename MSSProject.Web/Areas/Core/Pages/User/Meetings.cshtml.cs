using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSSProject.Data.Models;
using MSSProject.Web.Areas.Core.Data;
using MSSProject.Web.Areas.Identity.Data;
using MSSProject.Web.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSSProject.Web.Areas.Core.Pages.User
{
    [Authorize]
    public class MeetingsModel : DI_BasePageModel
    {
        public MeetingsModel(MSSCoreDbContext context,
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
        public IList<Room> RoomList { get; set; }
        [BindProperty]
        public IList<Meeting> MeetingList { get; set; }
        [BindProperty]
        public IList<MSSWebUser> UserList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            UserList = await AuthContext.Users
                .AsNoTracking()
                .ToListAsync();
            MeetingList = await Context.Meetings
                .AsNoTracking()
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteMeeting(int meetId)
        {
            Meeting = await Context.Meetings.FindAsync(meetId);
            Context.Meetings.Remove(Meeting);
            await Context.SaveChangesAsync();

            return Redirect("./Meetings");
        }
    }
}
