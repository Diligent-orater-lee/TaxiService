using Abstraction.RideRealTime;
using DTOs.RideRealtime;
using Microsoft.AspNetCore.SignalR;
using RideRealTime.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "TrustedOrigins",
                      builder =>
                      {
                          builder = builder.WithOrigins("http://localhost:8100");
                          builder.AllowAnyHeader();
                          builder.AllowAnyMethod();
                          builder.AllowCredentials();
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("send-location", async (MapLocationDTO location, IHubContext<UserMapHub, IUserMapHub> context) =>
{
    await context.Clients.All.Testing(location);
    return Results.NoContent();
});
app.MapHub<UserMapHub>("/map-service");

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("TrustedOrigins");

app.MapControllers();

app.Run();
