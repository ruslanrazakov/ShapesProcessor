using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShapesProcessor.UI;
using ShapesProcessor.UI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<ShapesProcessor.Lib.ShapesProcessor>();
builder.Services.AddSingleton<IForegroundShapesService, ForegroundShapesService>();
builder.Services.AddSingleton<IShapesGenerator, ShapesGenerator>();

await builder.Build().RunAsync();
