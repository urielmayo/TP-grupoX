using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend
{
    public static class DatabaseInitializer
    {

        public static async Task InitializeAsync(this WebApplication app)
        {
            

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = services.GetRequiredService<UserManager<Collaborator>>();
   
                await CreateRolesAsync(roleManager);
                await CreateAdminUserAsync(userManager);
                await CreateDocumentTypeAsync(scope.ServiceProvider.GetRequiredService<ApplicationDbContext>());
            }
            
        }

        private static async Task CreateRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin", "Collaborator" };
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
            var adminEmail = "ONGAdmin@admin.com";
            var adminPassword = "Admin@1234"; 

            var existingAdmin = await userManager.FindByEmailAsync(adminEmail);
            if (existingAdmin == null)
            {
                var adminUser = new Collaborator()
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

        private static async Task CreateDocumentTypeAsync(ApplicationDbContext dbContext)
        {
            if (!dbContext.DocumentTypes.Any())
            {
                var tiposDeDocumentos = new List<DocumentType>
            {
                new DocumentType { Description = "DNI" },
                new DocumentType { Description = "CUIL" },
                new DocumentType { Description = "CUIT" },
                new DocumentType { Description = "Pasaporte" },
                new DocumentType { Description = "Libreta Cívica" },
                new DocumentType { Description = "Libreta de Enrolamiento" }
            };

                dbContext.DocumentTypes.AddRange(tiposDeDocumentos);
                await dbContext.SaveChangesAsync();

                Console.WriteLine("Se dieron de alta los tipos de documentos correctamente.");
            }
        }
    }
}
