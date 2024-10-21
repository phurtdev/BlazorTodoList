using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebClient.Services;
using WebClient;
using System.Net.Http.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Create HttpClient for retrieving the appsettings.json file
var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };

// Fetch the settings from the appsettings.json file in wwwroot
var settings = await httpClient.GetFromJsonAsync<AppSettings>("appsettings.json");

// Register HttpClient to communicate with the API, using the API URL from appsettings.json
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(settings.ApiUrl) });

// Register TodoService for API operations
builder.Services.AddScoped<ITodoService, TodoService>();

await builder.Build().RunAsync();

// Create a class to map the settings from appsettings.json
public class AppSettings
{
    public string ApiUrl { get; set; }
}

