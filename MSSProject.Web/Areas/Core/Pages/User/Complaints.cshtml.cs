using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSSProject.Data.Models;
using MSSProject.Web.Areas.Core.Data;
using MSSProject.Web.Areas.Identity.Data;
using MSSProject.Web.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MSSProject.Web.Areas.Core.Pages.User
{
    [Authorize]
    public class ComplaintsModel : DI_BasePageModel
    {
        public ComplaintsModel(MSSCoreDbContext context,
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
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            public string CreatorId { get; set; }
            public string CreatorName { get; set; }
            public string CreatorEmail { get; set; }
            public DateTime DateCreated { get; set; }

            [Required]
            [MaxLength(300)]
            [Display(Name = "complaint text")]
            public string ComplaintText { get; set; }

            public string Response { get; set; }
            public ComplaintStatus AdminStatus { get; set; }
        }
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
        public async Task<IActionResult> OnPostCreateComplaintAsync()
        {
            var user = await UserManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                Complaint = new Complaint
                {
                    CreatorId = user.Id,
                    CreatorName = user.FirstName + " " + user.LastName,
                    CreatorEmail = user.Email,
                    DateCreated = DateTime.Now,
                    ComplaintText = Input.ComplaintText,
                    Response = null,
                    AdminStatus = ComplaintStatus.Incomplete
                };
                await Context.Complaints.AddAsync(Complaint);
                await Context.SaveChangesAsync();

                return Redirect("./Complaints");
            }
            return Page();
        }
    }
}
