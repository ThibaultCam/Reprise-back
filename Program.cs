using Microsoft.AspNetCore.Authentication;
using Reprise_back.Service;
using Reprise_back.Service.Interface;
using Reprise_back.Repository;
using Reprise_back.Repository.Interface;
using Microsoft.EntityFrameworkCore;
{
    
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<ISeriesRepository, SeriesRepository>();

builder.Services.AddScoped<IFilmService, FilmService>();
builder.Services.AddScoped<ISeriesService, SeriesService>();
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

var app = builder.Build();

app.UseCors("AngularPolicy");

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
