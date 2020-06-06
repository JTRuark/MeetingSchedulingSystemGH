using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MSSProject.Data.Models;
using MSSProject.Web.Areas.Core.Data;
using MSSProject.Web.Areas.Identity.Data;
using MSSProject.Web.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MSSProject.Web.Areas.Core.Pages.User
{
    [Authorize]
    public class CreatePaymentModel : DI_BasePageModel
    {
        public CreatePaymentModel(MSSCoreDbContext context,
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
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required]
            [RegularExpression("^[a-zA-Z]+$",
                ErrorMessage = "Please enter valid letters and punctuation.")]
            public string FirstName { get; set; }

            [Required]
            [RegularExpression("^[a-zA-Z]+$",
                ErrorMessage = "Please enter valid letters and punctuation.")]
            public string LastName { get; set; }

            [Required]
            [StringLength(16, ErrorMessage = "Card number must be sixteen digits.", MinimumLength = 16)]
            public string CardNumber { get; set; }

            [Required]
            public string CardType { get; set; }

            [Required]
            [StringLength(4, ErrorMessage = "Only three or four digits allowed.", MinimumLength = 3)]
            public string Cvv { get; set; }

            [Required]
            public DateTime ExpirationDate { get; set; }

            [Required]
            [StringLength(5, ErrorMessage = "Zip code must be five digits.", MinimumLength = 5)]
            public string BillingZipCode { get; set; }
        }
        public async Task<IActionResult> OnPostCreatePaymentAsync()
        {
            var user = await UserManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                PaymentInfo = new PaymentInfo
                {
                    OwnerId = user.UserName,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    CardNumber = Input.CardNumber,
                    CardType = Input.CardType,
                    Cvv = Input.Cvv,
                    ExpirationDate = Input.ExpirationDate,
                    BillingZipCode = Input.BillingZipCode
                };
                await Context.Payments.AddAsync(PaymentInfo);
                await Context.SaveChangesAsync();

                return Redirect("./PaymentInfo");
            }
            return Page();
        }
    }
}
