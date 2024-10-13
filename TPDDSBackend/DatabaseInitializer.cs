using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
                var dbContextFactory = services.GetRequiredService<IDbContextFactory<ApplicationDbContext>>();

                await CreateRolesAsync(roleManager);
                await CreateAdminUserAsync(userManager);

                var tasks = new List<Task>()
                {
                    CreateDocumentTypeAsync(dbContextFactory),
                    CreateDeliveryReasonAsync(dbContextFactory),
                    CreateFoodStatesAsync(dbContextFactory),
                };
                await Task.WhenAll(tasks);
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

        private static async Task CreateDocumentTypeAsync(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            await using var dbContext = dbContextFactory.CreateDbContext();
            if (!dbContext.DocumentTypes.Any())
            {
                var documentTypes = new List<DocumentType>
            {
                new DocumentType { Description = "DNI" },
                new DocumentType { Description = "CUIL" },
                new DocumentType { Description = "CUIT" },
                new DocumentType { Description = "Pasaporte" },
                new DocumentType { Description = "Libreta Cívica" },
                new DocumentType { Description = "Libreta de Enrolamiento" }
            };

                dbContext.DocumentTypes.AddRange(documentTypes);
                await dbContext.SaveChangesAsync();

                Console.WriteLine("Se dieron de alta los tipos de documentos correctamente.");
            }
        }

        private static async Task CreateDeliveryReasonAsync(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            await using var dbContext = dbContextFactory.CreateDbContext();
            
            if (!dbContext.DeliveryReasons.Any())
            {
                var deliveryReasons = new List<DeliveryReason>
            {
                new DeliveryReason { ReasonDescription = "Desperfecto en la heladera" },
                new DeliveryReason { ReasonDescription = "Falta de viandas en la heladera destino" }
            };

                dbContext.DeliveryReasons.AddRange(deliveryReasons);
                await dbContext.SaveChangesAsync();

                Console.WriteLine("Se dieron de alta las razones de mover viandas de heladera");
            }
        }

        private static async Task CreateFoodStatesAsync(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            await using var dbContext = dbContextFactory.CreateDbContext();
            
            if (!dbContext.FoodState.Any())
            {
                var foodStates = new List<FoodState>
            {
                new FoodState { Description = "Disponible" },
                new FoodState { Description = "Vencida" },
                new FoodState { Description = "Entregada" },
            };

                dbContext.FoodState.AddRange(foodStates);
                await dbContext.SaveChangesAsync();

                Console.WriteLine("Se dieron de alta los estados de las viandas");
            }
        }
    }
}
