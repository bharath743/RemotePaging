using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RemotePaging;
using RemotePaging.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//Adding telerik to the IoC container
builder.Services.AddTelerikBlazor();

//registering our service
builder.Services.AddScoped<ServerService>();

await builder.Build().RunAsync();
