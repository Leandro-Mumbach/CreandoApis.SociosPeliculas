using Microsoft.EntityFrameworkCore;
using MinimalApiSociosPeliculas.Data;
using MinimalApiSociosPeliculas.Models;
using MinimalApiSociosPeliculas.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add DB Peliculas
builder.Services.AddDbContext<PeliculaDbContext>(options =>
    options.UseInMemoryDatabase("PeliculasDb"));
//Add method IPeliculas
builder.Services.AddScoped<IPeliculaRepository, PeliculaRepository>();

//Add DB Socios
builder.Services.AddDbContext<SocioDbContext>(options =>
    options.UseInMemoryDatabase("SociosDb"));
//Add method ISocios
builder.Services.AddScoped<ISocioRepository, SocioRepository>();

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

// Metodos Http Peliculas
app.MapGet("/api/peliculas", (IPeliculaRepository Ipelicula) =>
{
    var peliculas = Ipelicula.GetAllPeliculas();
    return Results.Ok(peliculas);
});

app.MapPost("/api/peliculas", (IPeliculaRepository Ipelicula, Pelicula pelicula) =>
{
    Ipelicula.AddPelicula(pelicula);
    return Results.Created($"/api/peliculas/{pelicula.Id}", pelicula);
});

app.MapPut("/api/peliculas/{id}", (IPeliculaRepository Ipelicula, int id, Pelicula updatedPelicula) =>
{
    var pelicula = Ipelicula.GetPeliculaById(id);
    if (pelicula == null)
    {
        return Results.NotFound();
    }
    pelicula.Duración = updatedPelicula.Duración;
    pelicula.Descripción = updatedPelicula.Descripción;
    Ipelicula.UpdatePelicula(pelicula);
    return Results.NoContent();
});

app.MapDelete("/api/pelicula/{id}", (IPeliculaRepository Ipelicula, int id) =>
{
    var pelicula = Ipelicula.GetPeliculaById(id);
    if (pelicula == null)
    {
        return Results.NotFound();
    }
    Ipelicula.DeletePelicula(id);
    return Results.NoContent();
});

// Metodos Http Socios
app.MapGet("/api/socios", (ISocioRepository ISocio) =>
{
    var socios = ISocio.GetAllSocios();
    return Results.Ok(socios);
});

app.MapPost("/api/socio", (ISocioRepository Isocio, Socio socio) =>
{
    Isocio.AddSocio(socio);
    return Results.Created($"/api/socios/{socio.Id}", socio);
});

app.MapPut("/api/socio/{id}", (ISocioRepository Isocio, int id, Socio updatedSocio) =>
{
    var socio = Isocio.GetSocioById(id);
    if (socio == null)
    {
        return Results.NotFound();
    }
    socio.Nombre = updatedSocio.Nombre;
    socio.Apellido = updatedSocio.Apellido;
    socio.Dirección = updatedSocio.Dirección;
    Isocio.UpdateSocio(socio);
    return Results.NoContent();
});

app.MapDelete("/api/socio/{id}", (ISocioRepository Isocio, int id) =>
{
    var socio = Isocio.GetSocioById(id);
    if (socio == null)
    {
        return Results.NotFound();
    }
    Isocio.DeleteSocio(id);
    return Results.NoContent();
});

app.Run();