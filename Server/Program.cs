global using Microsoft.EntityFrameworkCore;
global using RegistroAportes.Shared;
global using RegistroAportes.Server.DAL;
global using RegistroAportes.Server.Services.PersonaServices;
global using RegistroAportes.Server.Services.TipoAporteServices;
using Microsoft.AspNetCore.ResponseCompression;


var builder = WebApplication.CreateBuilder(args);

var ConStr = builder.Configuration.GetConnectionString("ConStr");
// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();


builder.Services.AddEndpointsApiExplorer();

//Scopes...
builder.Services.AddDbContext<Context>(options => options.UseSqlite(ConStr));
builder.Services.AddScoped<IPersonaService, PersonaService>();
builder.Services.AddScoped<ITipoAporteService, TipoAporteService>();



var app = builder.Build();

app.UseSwaggerUI();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
