using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Security.Claims;

namespace HsPXL.Data
{
    public class IdentitySeedData
    {

        private const string adminUser = "Admin";
        private const string adminPassword = "Admin1234$";
        private const string RoleAdmin = "Administrator";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            
            HsIdentityDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<HsIdentityDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            UserManager<IdentityUser> userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            RoleManager<IdentityRole> roleManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

           

            IdentityUser user = await userManager.FindByNameAsync(adminUser);
          //  IdentityRole RoleUser = await roleManager.FindByNameAsync(RoleAdmin);

            if (user == null)
            {
                user = new IdentityUser("Admin");
                user.Email = "admin@pxl.com";
                user.PhoneNumber = "141-3866";



                IdentityRole identityRole = new IdentityRole
                {
                    Name = RoleAdmin
                };

                IdentityRole identityRoleRegularUser = new IdentityRole
                {
                    Name = "User"
                };
                await roleManager.CreateAsync(identityRole);
                await roleManager.CreateAsync(identityRoleRegularUser);

                var role = await roleManager.FindByNameAsync(RoleAdmin);

                await userManager.CreateAsync(user, adminPassword);

                var userOutDb = await userManager.FindByEmailAsync(user.Email);
                
                await userManager.AddToRoleAsync(userOutDb, role.Name);


            }

            //var adminRole = await roleManager.FindByNameAsync("Admin");
            //if (adminRole == null)
            //{User123$
            //    adminRole = new IdentityRole("Administrator");
            //    await roleManager.CreateAsync(adminRole);

            //    //await roleManager.AddClaimAsync(adminRole, new Claim(CustomClaimTypes.Permission, "HsPXL.view"));
            //    //await roleManager.AddClaimAsync(adminRole, new Claim(CustomClaimTypes.Permission, "HsPXL.create"));
            //    //await roleManager.AddClaimAsync(adminRole, new Claim(CustomClaimTypes.Permission, "HsPXL.update"));
            //}


            //if (RoleUser == null)
            //{
            //    var currentUser = await userManager.FindByNameAsync(user.UserName);
            //    RoleUser.Id = currentUser.Id.ToString();
            //    RoleUser.Name = currentUser.NormalizedUserName;


            //}

        }

    }
}
