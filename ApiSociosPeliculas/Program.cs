using ApiSociosPeliculas.Data;
using ApiSociosPeliculas.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<SocioDbContext>
    (options => options.UseInMemoryDatabase("SociosDb"));
builder.Services.AddScoped<ISocioRepository, SocioRepository>();

builder.Services.AddDbContext<PeliculaDbContext>
    (options => options.UseInMemoryDatabase("PeliculasDb"));
builder.Services.AddScoped<IPeliculaRepository, PeliculaRepository>();


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
