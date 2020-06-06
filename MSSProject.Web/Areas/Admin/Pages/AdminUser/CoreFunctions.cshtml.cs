using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MSSProject.Web.Areas.Admin.Pages.AdminUser
{
    [Authorize(Roles = "Administrator")]
    public class CoreFunctionsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
