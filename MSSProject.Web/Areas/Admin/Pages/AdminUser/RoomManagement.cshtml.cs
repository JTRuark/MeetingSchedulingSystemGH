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

namespace MSSProject.Web.Areas.Admin.Pages.AdminUser
{
    [Authorize(Roles = "Administrator")]
    public class RoomManagementModel : DI_BasePageModel
    {
        public RoomManagementModel(MSSCoreDbContext context,
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
        public Room Room { get; set; }
        public IList<Room> RoomList { get; set; }
        public IList<Meeting> MeetingList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            MeetingList = await Context.Meetings
                .AsNoTracking()
                .ToListAsync();
            RoomList = await Context.Rooms
                .AsNoTracking()
                .ToListAsync();

            if (RoomList == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostChangeAsync(int id)
        {
            var roomToUpdate = await Context.Rooms.FindAsync(id);

            if (roomToUpdate == null)
            {
                return NotFound();
            }
            if (roomToUpdate.Availability == Availability.Available)
            {
                roomToUpdate.Availability = Availability.Unavailable;
                Context.Update(roomToUpdate);
                await Context.SaveChangesAsync();
            }
            else
            {
                roomToUpdate.Availability = Availability.Available;
                Context.Update(roomToUpdate);
                await Context.SaveChangesAsync();
            }
            return Redirect("./RoomManagement");
        }
    }
}
