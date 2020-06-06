using Microsoft.AspNetCore.Identity;
using MSSProject.Data.Models;
using MSSProject.Web.Areas.Core.Data;
using MSSProject.Web.Areas.Identity.Data;

namespace MSSProject.Web.Data
{
    public class ModelDataHandler
    {

        protected Room Room { get; set; }
        protected Meeting Meeting { get; set; }
        protected Complaint Complaint { get; set; }
        protected PaymentInfo PaymentInfo { get; set; }
        protected MSSCoreDbContext Context { get; set; }
        public UserManager<MSSWebUser> UserManager { get; set; }

        public ModelDataHandler() { }
        public UserManager<MSSWebUser> GetUserManager() { return UserManager; }
    }
}
