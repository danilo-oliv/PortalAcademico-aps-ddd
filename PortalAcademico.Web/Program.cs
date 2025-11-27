using Microsoft.EntityFrameworkCore;
using PortalAcademico.Aplicacao.Interfaces;
using PortalAcademico.Aplicacao.Mapping;
using PortalAcademico.Aplicacao.Services;
using PortalAcademico.Dominio.Interfaces;
using PortalAcademico.Infra.Context;
using PortalAcademico.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PortalAcademicoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<ITurmaRepository, TurmaRepository>();

builder.Services.AddScoped<IAlunoAppService, AlunoAppService>();
builder.Services.AddScoped<ITurmaAppService, TurmaAppService>();

builder.Services.RegisterMapsterConfiguration();



builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Aluno}/{action=Index}/{id?}");

app.Run();
