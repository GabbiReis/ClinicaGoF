using ClinicaGoF.Application.Services;
using ClinicaGoF.Application.Services.Interfaces;
using ClinicaGoF.Domain.Repository.Interfaces;
using ClinicaGoF.Infrastructure.Data;
using ClinicaGoF.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Swagger padrão do ASP.NET Core
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ClinicaGoF API",
        Version = "v1",
        Description = "API para agendamento de consultas médicas com aplicação de Design Patterns"
    });
});

// Injeção de dependência
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("ClinicaGoFDb"));
builder.Services.AddScoped(typeof(IRepository<>), typeof(InMemoryRepository<>));

// Services
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IMedicoService, MedicoService>();
builder.Services.AddScoped<IConsultaService, ConsultaService>();
builder.Services.AddScoped<IMediator, ClinicaMediator>();

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

builder.Services.AddScoped<IMediator, ClinicaMediator>();

