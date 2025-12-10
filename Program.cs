using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Logging;
using Reprise_back.Middlewares;
using Reprise_back.Repository;
using Reprise_back.Repository.Interface;
using Reprise_back.Service;
using Reprise_back.Service.Interface;
{

}

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<ISeriesRepository, SeriesRepository>();
builder.Services.AddScoped<IUserDataFilmRepository, UserDataFilmRepository>();

builder.Services.AddScoped<IFilmService, FilmService>();
builder.Services.AddScoped<ISeriesService, SeriesService>();
builder.Services.AddScoped<IUserDataFilmService, UserDataFilmService>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

// gestion de la Serialization
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });


// CORS pour Angular (adapter l’URL)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularPolicy", b =>
    {
        b.WithOrigins("http://localhost:4200")
         .AllowAnyHeader()
         .AllowAnyMethod();
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddMicrosoftIdentityWebApi(options =>

        {
            configuration.Bind("AzureAd", options);
            options.Events = new JwtBearerEvents();

            options.Events = new JwtBearerEvents
            {
                OnTokenValidated = context =>
                {
                    var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();

                    // Access the scope claim (scp) directly
                    var scopeClaim = context.Principal?.Claims.FirstOrDefault(c => c.Type == "scp")?.Value;

                    if (scopeClaim != null)
                    {
                        logger.LogInformation("Scope found in token: {Scope}", scopeClaim);
                    }
                    else
                    {
                        logger.LogWarning("Scope claim not found in token.");
                    }

                    return Task.CompletedTask;
                },
                OnAuthenticationFailed = context =>
                {
                    var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
                    logger.LogError("Authentication failed: {Message}", context.Exception.Message);
                    return Task.CompletedTask;
                },
                OnChallenge = context =>
                {
                    var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
                    logger.LogError("Challenge error: {ErrorDescription}", context.ErrorDescription);
                    return Task.CompletedTask;
                }
            };
        }, options => { configuration.Bind("AzureAd", options); });

// The following flag can be used to get more descriptive errors in development environments
IdentityModelEventSource.ShowPII = false;

var app = builder.Build();

app.UseCors("AngularPolicy");
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
