using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MSSProject.Web.Areas.Core.Data;
using MSSProject.Web.Areas.Identity.Data;

namespace MSSProject.Web.Data
{
    public class DI_BasePageModel : PageModel
    {
        protected MSSCoreDbContext Context { get; }
        protected IAuthorizationService AuthorizationService { get; }
        protected UserManager<MSSWebUser> UserManager { get; }
        protected RoleManager<IdentityRole> RoleManager { get; }
        protected MSSWebAuthContext AuthContext { get; }

        public DI_BasePageModel(
            MSSCoreDbContext context,
            IAuthorizationService authorizationService,
            UserManager<MSSWebUser> userManager,
            RoleManager<IdentityRole> roleManager,
            MSSWebAuthContext authContext) : base()
        {
            Context = context;
            UserManager = userManager;
            RoleManager = roleManager;
            AuthorizationService = authorizationService;
            AuthContext = authContext;
        }
    }
}
