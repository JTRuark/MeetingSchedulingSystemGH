using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MSSProject.Web.Areas.Identity.Data;
using MSSProject.Web.Data;

[assembly: HostingStartup(typeof(MSSProject.Web.Areas.Identity.IdentityHostingStartup))]
namespace MSSProject.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<MSSWebAuthContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MSSWebAuthContextConnection")));

                services.AddDefaultIdentity<MSSWebUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<MSSWebAuthContext>();
            });
        }
    }
}