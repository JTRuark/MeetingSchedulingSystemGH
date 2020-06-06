using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MSSProject.Web.Areas.Core.Data;
using MSSProject.Web.Areas.Identity.Data;
using MSSProject.Web.Data;

namespace MSSProject.Web.Areas.Admin.Pages.AdminUser
{
    [Authorize(Roles = "Administrator")]
    public class IndexModel : DI_BasePageModel
    {
        public IndexModel(MSSCoreDbContext context,
            IAuthorizationService authorizationService,
            UserManager<MSSWebUser> userManager,
            RoleManager<IdentityRole> roleManager,
            MSSWebAuthContext authContext) : base(context,
                                                          authorizationService,
                                                          userManager,
                                                          roleManager,
                                                          authContext)
        { }
        public void OnGet()
        {
        }
    }
}
