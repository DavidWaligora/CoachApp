using CoachApp.DAL.Data;
using CoachApp.DAL.Data.Models;
using CoachApp.Services;
using Microsoft.AspNetCore.Identity; // Ensure this namespace is correct based on your project structure

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Database services registration
builder.Services.AddDatabaseServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<CoachAppContext>()
                .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// DatabaseProvider registration
app.Services.AddDatabaseServicesProvider();

app.Run();
