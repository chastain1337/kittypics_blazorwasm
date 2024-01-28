using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using KittyPics_BlazorWASM;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

#if DEBUG
    var baseUrl = "https://localhost:7054/";
#else
    var baseUrl = "https://kittypics-api.onrender.com/";
#endif

builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri(baseUrl)});

await builder.Build().RunAsync();