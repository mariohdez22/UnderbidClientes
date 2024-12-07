using Blazored.Modal;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using Underbid.Client;
using Underbid.Client.Services.NET.Interfaces;
using Underbid.Client.Services.NET.Servicios;
using Underbid.Client.Services.SignalR;
using Underbid.Client.Services.Spring.Interfaces;
using Underbid.Client.Services.Spring.Servicios;
using Underbid.Shared.DTOs;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

builder.Services.AddHttpClient("ApiNet", options =>
{
    options.BaseAddress = new Uri("https://localhost:7050/");
});

builder.Services.AddHttpClient("ApiSpring", options =>
{
    options.BaseAddress = new Uri("http://localhost:8082/");
});

builder.Services.AddOidcAuthentication(options =>
{
    options.ProviderOptions.Authority = "http://localhost:8080/realms/UnderBid";
    options.ProviderOptions.ClientId = "fastapi-client";
    options.ProviderOptions.ResponseType = "code";
});


//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

builder.Services.AddScoped<IChatService, ChatService>();
builder.Services.AddScoped<ITransaccionesService, TransaccionesService>();
builder.Services.AddScoped<IMensajesService, MensajesService>();
builder.Services.AddScoped<IPujasService, PujasService>();
builder.Services.AddScoped<IPublicacionesService, PublicacionesService>();
builder.Services.AddSingleton<IHubRegistroService, HubRegistroService>();

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

builder.Services.AddRadzenComponents();
builder.Services.AddBlazoredModal();

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

await builder.Build().RunAsync();
