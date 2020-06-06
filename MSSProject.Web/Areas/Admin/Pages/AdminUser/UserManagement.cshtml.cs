using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSSProject.Web.Areas.Core.Data;
using MSSProject.Web.Areas.Identity.Data;
using MSSProject.Web.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSSProject.Web.Areas.Admin.Pages.AdminUser
{
    [Authorize(Roles = "Administrator")]
    public class UserManagementModel : DI_BasePageModel
    {
        public UserManagementModel(MSSCoreDbContext context,
            IAuthorizationService authorizationService,
            UserManager<MSSWebUser> userManager,
            RoleManager<IdentityRole> roleManager,
            MSSWebAuthContext authContext) : base(context,
                                                        authorizationService,
                                                        userManager,
                                                        roleManager,
                                                        authContext)
        { }
        public IList<MSSWebUser> UserList { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            UserList = await AuthContext.Users.AsNoTracking().ToListAsync();
            if (UserList == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAddAdmin(string id)
        {
            var userToUpdate = await UserManager.FindByIdAsync(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }
            if (await UserManager.IsInRoleAsync(userToUpdate, "Administrator") == false)
            {
                await UserManager.RemoveFromRoleAsync(userToUpdate, "StandardUser");
                await UserManager.AddToRoleAsync(userToUpdate, "Administrator");
                await AuthContext.SaveChangesAsync();
            }
            else
            {
                await UserManager.RemoveFromRoleAsync(userToUpdate, "Administrator");
                await UserManager.AddToRoleAsync(userToUpdate, "StandardUser");
                await AuthContext.SaveChangesAsync();
            }
            return Redirect("./UserManagement");
        }
    }
}
