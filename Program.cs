using ApiGHMM.Data;
using ApiGHMM.Repositorios.Interfaces;
using ApiGHMM.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<Contexto>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
    );

builder.Services.AddScoped<IFuncionariosRepositorio, FuncionariosRepositorio>();
builder.Services.AddScoped<ICargoRepositorio, CargoRepositorio>();
builder.Services.AddScoped<ISetorRepositorio, SetorRepositorio>();
builder.Services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();
builder.Services.AddScoped<IFabricanteRepositorio, FabricanteRepositorio>();
builder.Services.AddScoped<IPecaRepositorio, PecaRepositorio>();
builder.Services.AddScoped<ITipoMaquinaRepositorio, TipoMaquinaRepositorio>();
builder.Services.AddScoped<ITipoManutencaoRepositorio, TipoManutencaoRepositorio>();
builder.Services.AddScoped<ICategoriaPecaRepositorio, CategoriaPecaRepositorio>();
builder.Services.AddScoped<IRelatorioRepositorio, RelatorioRepositorio>();
builder.Services.AddScoped<IManutencaoEPecasRepositorio, ManutencaoEPecasRepositorio>();
builder.Services.AddScoped<IMaquinaRepositorio, MaquinaRepositorio>();
builder.Services.AddScoped<IManutencaoRepositorio, ManutencaoRepositorio>();

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
