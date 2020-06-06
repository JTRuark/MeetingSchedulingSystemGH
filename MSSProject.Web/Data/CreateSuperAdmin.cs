using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MSSProject.Web.Areas.Identity.Data;
using System;
using System.Threading.Tasks;

namespace MSSProject.Web.Data
{
    public static class CreateSuperAdmin
    {
        public static async Task Initialize(IConfiguration config, IServiceProvider serviceProvider)
        {
            await CreateSupAdmin(serviceProvider, config);
            await SeedUsers(serviceProvider, config);
        }
        private static async Task CreateSupAdmin(IServiceProvider serviceProvider, IConfiguration Configuration)
        {
            var RoleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetService<UserManager<MSSWebUser>>();

            string[] roleNames = { "Administrator", "StandardUser" };
            IdentityResult roleResult;

            foreach (var role in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(role));
                }
            }
            var _admin = await UserManager.FindByIdAsync(Configuration["SupAdminLogin"]);
            if (_admin == null)
            {
                var supAdmin = new MSSWebUser
                {
                    //this would normally be seeded elsewhere, but for the purposes of this project
                    //and limitations, we had to hard code the user and pass for the base admin.
                    //originally we used secrets and configuration to seed.
                    //same applies for the seeded users below.
                    UserName = "dasadmin",
                    FirstName = "Uber",
                    LastName = "Admin",
                    Email = "admin@pennstatesoft.com",
                    EmailConfirmed = true
                };

                var createSupAdmin = await UserManager.CreateAsync(supAdmin, Configuration["SupAdminPass"]);
                if (createSupAdmin.Succeeded)
                {
                    await UserManager.AddToRoleAsync(supAdmin, "Administrator");
                }
            }
        }
        private static async Task SeedUsers(IServiceProvider serviceProvider, IConfiguration config)
        {
            var UserManager = serviceProvider.GetService<UserManager<MSSWebUser>>();

            if (UserManager.FindByNameAsync("dsmith").Result == null)
            {
                var seedUser = new MSSWebUser
                {
                    UserName = "dsmith",
                    FirstName = "Dave",
                    LastName = "Smith",
                    Email = "dsmith@pennstatesoft.com",
                    EmailConfirmed = true
                };
                var createUser = await UserManager.CreateAsync(seedUser, "JavaMan12!");
                if (createUser.Succeeded)
                {
                    await UserManager.AddToRoleAsync(seedUser, "StandardUser");
                }
            }
            if (UserManager.FindByNameAsync("tsawyer").Result == null)
            {
                var seedUser = new MSSWebUser
                {
                    UserName = "tsawyer",
                    FirstName = "Tom",
                    LastName = "Sawyer",
                    Email = "tsawyer@pennstatesoft.com",
                    EmailConfirmed = true
                };
                var createUser = await UserManager.CreateAsync(seedUser, "JavaMan12!");
                if (createUser.Succeeded)
                {
                    await UserManager.AddToRoleAsync(seedUser, "StandardUser");
                }
            }
            if (UserManager.FindByNameAsync("bjohnson").Result == null)
            {
                var seedUser = new MSSWebUser
                {
                    UserName = "bjohnson",
                    FirstName = "Bob",
                    LastName = "Johnson",
                    Email = "bjohnson@pennstatesoft.com",
                    EmailConfirmed = true
                };
                var createUser = await UserManager.CreateAsync(seedUser, "JavaMan12!");
                if (createUser.Succeeded)
                {
                    await UserManager.AddToRoleAsync(seedUser, "StandardUser");
                }
            }
        }
    }
}

