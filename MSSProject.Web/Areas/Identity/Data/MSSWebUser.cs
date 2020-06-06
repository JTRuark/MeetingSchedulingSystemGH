using Microsoft.AspNetCore.Identity;

namespace MSSProject.Web.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the MSSWebUser class
    public class MSSWebUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }

    }
}
