using AutoMapper;
using ArticulosAPI;
using ArticulosAPI.Repositorios; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configurar AutoMapper
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Agregar servicio del repositorio
builder.Services.AddScoped<IArticuloRepositorio, ArticuloRepositorio>();


// Otros servicios que ya estén configurados
builder.Services.AddControllers();

// Agregar Swagger si lo estás usando
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar la tubería HTTP (middleware)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
