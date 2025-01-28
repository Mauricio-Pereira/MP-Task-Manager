using System.Text.Json;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MPTaskManager.Shared.Utils;
using MPTaskManager.Web;
using MPTaskManager.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5001") });

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7003") });


builder.Services.Configure<JsonSerializerOptions>(options =>
{
    options.Converters.Add(new CustomDateTimeConverter("yyyy-MM-dd HH:mm"));
});

builder.Services.AddScoped<TaskService>();

await builder.Build().RunAsync();