global using RegistroAportes.Shared.Models;
global using RegistroAportes.Shared;
global using System.Net.Http.Json;
global using RegistroAportes.Client.Services.PersonaServices;
global using Radzen.Blazor;
global using Radzen;
global using Radzen.Blazor.Rendering;




using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RegistroAportes.Client;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IPersonaService, PersonaService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<DialogService>();

await builder.Build().RunAsync();
