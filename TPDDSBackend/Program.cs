using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using QuestPDF.Infrastructure;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using Telegram.Bot;
using TPDDSBackend;
using TPDDSBackend.Aplication;
using TPDDSBackend.Aplication.BackgroundServices;
using TPDDSBackend.Aplication.BackgroundServices.Services;
using TPDDSBackend.Aplication.Formatters;
using TPDDSBackend.Aplication.Services;
using TPDDSBackend.Aplication.Services.Strategies;
using TPDDSBackend.Aplication.Validators;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Interfaces;
using TPDDSBackend.Infrastructure.Repositories;
using TPDDSBackend.Infrastructure.Services;
using TPDDSBackend.Middlewares;

QuestPDF.Settings.License = LicenseType.Community;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();

builder.Services.AddIdentity<Collaborator, IdentityRole>(options =>
{
    // Configuración de políticas de contraseña
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
    //options.Password.RequiredUniqueChars = 3;
    // Configuración de bloqueo por intentos fallidos
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.AllowedForNewUsers = true;
    // Deshabilitar confirmación de correo electrónico
    options.SignIn.RequireConfirmedEmail = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddPasswordValidator<CommonPasswordValidator>();

builder.Services.AddControllers(options =>
{
    options.RespectBrowserAcceptHeader = true;

    // Otros formatters
    options.OutputFormatters.Add(new CsvOutputFormatter());
    options.OutputFormatters.Add(new PdfOutputFormatter());
}).AddFluentValidation(fv =>
   {
     fv.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
    }
);
builder.Services.AddMemoryCache();
builder.Services.AddScoped<ITechnicianRepository, TechnicianRepository>();
builder.Services.AddScoped<VisitRegistrationService>();
builder.Services.AddHttpClient<ITelegramBotClient, TelegramBotClient>(client =>
    new TelegramBotClient(builder.Configuration["TelegramBot:Token"])
);
builder.Services.AddSingleton<TelegramBotHandler>();
builder.Services.AddHostedService<TelegramBotBackgroundService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.ExampleFilters();
});
builder.Services.AddSwaggerExamplesFromAssemblyOf(typeof(Program));

builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseLazyLoadingProxies().UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IEmailSender<Collaborator>, DummyEmailSender>();
builder.Services.AddTransient<IGenericRepository<Fridge>, FridgeRepository>();
builder.Services.AddTransient<IGenericRepository<Food>, FoodRepository>();
builder.Services.AddTransient<IGenericRepository<FoodState>, FoodStateRepository>();
builder.Services.AddTransient<IGenericRepository<Technician>, TechnicianRepository>();
builder.Services.AddScoped<IContributionRepository, ContributionRepository>();
builder.Services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
builder.Services.AddScoped<IBenefitCoefficientsRepository, BenefitCoefficientsRepository>();
builder.Services.AddScoped<IBenefitExchangesRepository, BenefitExchangesRepository>();
builder.Services.AddScoped<IFridgeIncidentRepository, FridgeIncidentRepository>();
builder.Services.AddScoped<IFridgeRepository, FridgeRepository>();
builder.Services.AddScoped<ITechnicianVisitRepository, TechnicianVisitRepository>();
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<ICommunicationMediaRepository, CommunicationMediaRepository>();
builder.Services.AddScoped<IFridgeSubscriptionRepository, FridgeSubscriptionRepository>();
builder.Services.AddScoped<ICollaboratorRepository, CollaboratorRepository>();
builder.Services.AddTransient<IGenericRepository<PersonInVulnerableSituation>, PersonInVulnerableSituationRepository>();
builder.Services.AddScoped<IJwtFactory, JwtFactory>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


builder.Services.AddSwaggerGen(c =>
{
    // Define el esquema de seguridad para JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    // Aplica el esquema de seguridad a todos los endpoints
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddScoped<MoneyDonationStrategy>();
builder.Services.AddScoped<CardContributionStrategy>();
builder.Services.AddScoped<FoodContributionStrategy>();
builder.Services.AddScoped<FoodDeliveryContributionStrategy>();
builder.Services.AddScoped<OwnAFridgeContributionStratergy>();
builder.Services.AddScoped<BenefitContributionStrategy>();

builder.Services.AddScoped<IFileProcessorService,FileProcessorService>();
builder.Services.AddScoped<IAccumulatedPointsCalculator, AccumulatedPointsCalculator>();
builder.Services.AddScoped<IFridgeOpeningService, FridgeOpeningService>();

builder.Services.AddScoped<Dictionary<string, IContributionStrategy>>(provider => new Dictionary<string, IContributionStrategy>
{
    { "MoneyDonation", provider.GetRequiredService<MoneyDonationStrategy>() },
    { "VulnerablePersonCard", provider.GetRequiredService<CardContributionStrategy>() },
    { "FoodDonation", provider.GetRequiredService<FoodContributionStrategy>() },
    { "FoodDelivery", provider.GetRequiredService<FoodDeliveryContributionStrategy>() },
    { "FridgeOwner", provider.GetRequiredService<OwnAFridgeContributionStratergy>() },
    { "Benefit", provider.GetRequiredService<BenefitContributionStrategy>() }
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
    options.Events = new JwtBearerEvents
    {
        OnChallenge = async context =>
        {
            context.HandleResponse();

            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";
            var errorResponse = new
            {
                error = "Unauthorized",
                message = "El token es inválido o ha expirado."
            };
            await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(errorResponse));
        },
        OnForbidden = async context =>
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            context.Response.ContentType = "application/json";
            var errorResponse = new
            {
                error = "Forbidden",
                message = "No tienes permisos para acceder a este recurso."
            };
            await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(errorResponse));
        }
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
                          policy =>
                          {
                              policy.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                          });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAnyOrigin");
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();

await app.InitializeAsync();

app.Run();