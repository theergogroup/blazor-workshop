using BlazingPizza.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<OrderState>();

// Add auth services
builder.Services.AddApiAuthorization<PizzaAuthenticationState>();
//builder.Services.AddApiAuthorization();

//Adquire and send token with authenticated user
builder.Services
    .AddHttpClient<OrdersClient>(client=> client.BaseAddress= new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>()    
    ;
//Varios manejadores authentificados
builder.Services
    .AddHttpClient<OrdersQueries>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>()
    ;
builder.Services
    .AddHttpClient<OrdersCommands>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>()
    ;

await builder.Build().RunAsync();
