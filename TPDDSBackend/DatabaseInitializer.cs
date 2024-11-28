﻿using Microsoft.AspNetCore.Identity;
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
                    CreateNeighborhoodsAsync(dbContextFactory),
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

        private static async Task CreateNeighborhoodsAsync(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            await using var dbContext = dbContextFactory.CreateDbContext();

            if (!dbContext.Neighborhoods.Any())
            {
                var neighborhoods = new List<Neighborhood>
                {
                new Neighborhood { Name = "Agronomía" },
                new Neighborhood { Name = "Almagro" },
                new Neighborhood { Name = "Balvanera" },
                new Neighborhood { Name = "Barracas" },
                new Neighborhood { Name = "Belgrano" },
                new Neighborhood { Name = "Boedo" },
                new Neighborhood { Name = "Caballito" },
                new Neighborhood { Name = "Chacarita" },
                new Neighborhood { Name = "Coghlan" },
                new Neighborhood { Name = "Colegiales" },
                new Neighborhood { Name = "Constitución" },
                new Neighborhood { Name = "Flores" },
                new Neighborhood { Name = "Floresta" },
                new Neighborhood { Name = "La Boca" },
                new Neighborhood { Name = "La Paternal" },
                new Neighborhood { Name = "Liniers" },
                new Neighborhood { Name = "Mataderos" },
                new Neighborhood { Name = "Monte Castro" },
                new Neighborhood { Name = "Monserrat" },
                new Neighborhood { Name = "Nueva Pompeya" },
                new Neighborhood { Name = "Nuñez" },
                new Neighborhood { Name = "Palermo" },
                new Neighborhood { Name = "Parque Avellaneda" },
                new Neighborhood { Name = "Parque Chacabuco" },
                new Neighborhood { Name = "Parque Chas" },
                new Neighborhood { Name = "Parque Patricios" },
                new Neighborhood { Name = "Puerto Madero" },
                new Neighborhood { Name = "Recoleta" },
                new Neighborhood { Name = "Retiro" },
                new Neighborhood { Name = "Saavedra" },
                new Neighborhood { Name = "San Cristóbal" },
                new Neighborhood { Name = "San Nicolás" },
                new Neighborhood { Name = "San Telmo" },
                new Neighborhood { Name = "Vélez Sársfield" },
                new Neighborhood { Name = "Versalles" },
                new Neighborhood { Name = "Villa Crespo" },
                new Neighborhood { Name = "Villa del Parque" },
                new Neighborhood { Name = "Villa Devoto" },
                new Neighborhood { Name = "Villa General Mitre" },
                new Neighborhood { Name = "Villa Lugano" },
                new Neighborhood { Name = "Villa Luro" },
                new Neighborhood { Name = "Villa Ortúzar" },
                new Neighborhood { Name = "Villa Pueyrredón" },
                new Neighborhood { Name = "Villa Real" },
                new Neighborhood { Name = "Villa Riachuelo" },
                new Neighborhood { Name = "Villa Santa Rita" },
                new Neighborhood { Name = "Villa Soldati" },
                new Neighborhood { Name = "Villa Urquiza" }
            };

             dbContext.Neighborhoods.AddRange(neighborhoods);
             await dbContext.SaveChangesAsync();

             Console.WriteLine("Se dieron de alta los barrios");
            }
        }
    }
}
