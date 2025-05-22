using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OdontoVision.Infrastructure;
using OdontoVision.Application.Services;
using OdontoVision.Domain.Interfaces;
using OdontoVision.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados Oracle
builder.Services.AddDbContext<OdontoVisionDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OdontoVisionConnection")));

// Registro de dependências (Injeção de Dependência)
builder.Services.AddScoped<IDentistaRepository, DentistaRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IProcedimentoRepository, ProcedimentoRepository>();
builder.Services.AddScoped<IDiagnosticoRepository, DiagnosticoRepository>();

builder.Services.AddScoped<DentistaService>();
builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<ProcedimentoService>();
builder.Services.AddScoped<DiagnosticoService>();

// Adicionando Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "OdontoVision API",
        Version = "v1",
        Description = "API para gerenciamento de dentistas, pacientes, procedimentos e diagnósticos.",
        Contact = new OpenApiContact
        {
            Name = "Suporte OdontoVision",
            Email = "suporte@odontovision.com",
            Url = new Uri("https://odontovision.com/suporte")
        }
    });

    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

var app = builder.Build();

// Configuração do Middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "OdontoVision API v1");
    c.RoutePrefix = "swagger"; // Acessível em http://localhost:5094/swagger
});

// Middleware para exceções e segurança
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Middleware para requisições HTTP
// app.UseHttpsRedirection(); 
app.UseRouting();
app.UseAuthorization();

// Mapeamento dos Controllers
app.MapControllers();

// Inicialização da Aplicação
app.Run();
