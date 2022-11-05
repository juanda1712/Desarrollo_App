using Microsoft.EntityFrameworkCore;
using MinimalAPI.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WEB_APIContext>(obj => obj.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL")));

builder.Services.AddControllers().AddJsonOptions(opt =>
{ opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });


var ReglasCors = "ReglasCors";
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: ReglasCors, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

    });

});
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseCors(ReglasCors);

app.MapGet("Hola", () => "Hola Mundo");

app.MapGet("Listar", (WEB_APIContext _contex) =>
{
	try
	{
        return Results.Ok(_contex.Contactos.ToList());
    }
	catch (Exception ex)
	{

		return Results.BadRequest(new { Mensaje = ex.Message });
	}

    
});

app.MapGet("Detail /{id}", (int id, WEB_APIContext _contex) =>
{
    Contacto ObjContacto = _contex.Contactos.Where(c=>c.IdContacto == id).FirstOrDefault();
    
    if (ObjContacto == null)
    {
        return Results.BadRequest(new { mensaje = "No existe Datos" });
    }
	try
	{
        return Results.Ok(ObjContacto);
    }
	catch (Exception ex)
	{
        return Results.BadRequest(new { Mensaje = ex.Message });

    }
});

app.MapPost("Save", (Contacto objContacto ,WEB_APIContext _contex) =>
{
	try
	{
        _contex.Contactos.Add(objContacto);
         var resultado = _contex.SaveChanges();
        if (resultado > 0)
            return Results.Ok(new { Mesaje = "OK" });
        else
            return Results.BadRequest(new { Mesaje = "No es posible almacenar datos" });
	}
	catch (Exception ex)
	{
        return Results.BadRequest(new { Mensaje = ex.Message });
    }

});



app.Run();

