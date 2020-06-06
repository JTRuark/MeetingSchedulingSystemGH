using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSSProject.Data.Models;
using MSSProject.Web.Areas.Core.Data;
using MSSProject.Web.Areas.Identity.Data;
using MSSProject.Web.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MSSProject.Web.Areas.Admin.Pages.AdminUser
{

    [Authorize(Roles = "Administrator")]
    public class ComplaintManagementModel : DI_BasePageModel
    {
        public ComplaintManagementModel(MSSCoreDbContext context,
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
        public Complaint Complaint { get; set; }
        public IList<Complaint> ComplaintList { get; set; }

        [BindProperty, MaxLength(300)]
        public string AdminResponse { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            ComplaintList = await Context.Complaints
                .AsNoTracking()
                .ToListAsync();

            if (ComplaintList == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAddResponseAsync(int compId)
        {
            var response = AdminResponse;
            var complaint = await Context.Complaints.FindAsync(compId);
            if (response != complaint.Response)
            {
                complaint.Response = response;
            }
            complaint.AdminStatus = ComplaintStatus.ResponseCompleted;
            if (Complaint == null)
            {
                return NotFound();
            }

            Context.Update(complaint);
            await Context.SaveChangesAsync();

            return Redirect("./ComplaintManagement");
        }
    }
}
