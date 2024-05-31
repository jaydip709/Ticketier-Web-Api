using Microsoft.EntityFrameworkCore;
using Ticketier_WebApi.Core.AutoMapperConfig;
using Ticketier_WebApi.Core.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options=>
{
    var connectionString = builder.Configuration.GetConnectionString("Ticketier");
    options.UseSqlServer(connectionString);
});

builder.Services.AddAutoMapper(typeof(AutoMapperConfigProfile));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
