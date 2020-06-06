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
    public class PaymentInfoModel : DI_BasePageModel
    {
        public PaymentInfoModel(MSSCoreDbContext context,
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
        public PaymentInfo PaymentInfo { get; set; }
        [BindProperty]
        public IList<PaymentInfo> PaymentList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            PaymentList = await Context.Payments
                .AsNoTracking()
                .ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int payId)
        {
            PaymentInfo = await Context.Payments.FindAsync(payId);
            Context.Payments.Remove(PaymentInfo);
            await Context.SaveChangesAsync();

            return Redirect("./PaymentInfo");
        }
    }
}
