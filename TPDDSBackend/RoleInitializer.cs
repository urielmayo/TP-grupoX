using Microsoft.AspNetCore.Identity;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend
{
    public static class RoleInitializer
    {
        public static async Task InitializeRolesAsync(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = services.GetRequiredService<UserManager<Collaborator>>();

                await CreateRolesAsync(roleManager);
                await CreateAdminUserAsync(userManager);
            }
        }

        private static async Task CreateRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin", "User", "Manager" };
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        private static async Task CreateAdminUserAsync(UserManager<Collaborator> userManager)
        {
            var adminEmail = "admin@example.com";
            var adminPassword = "Admin@1234"; // defaultAdmin

            var existingAdmin = await userManager.FindByEmailAsync(adminEmail);
            if (existingAdmin == null)
            {
                var adminUser = new Collaborator
                {
                    UserName = adminEmail,
                    Email = adminEmail
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
                else
                {
                    throw new Exception("No se pudo crear el usuario admin.");
                }
            }
        }
    }
}
