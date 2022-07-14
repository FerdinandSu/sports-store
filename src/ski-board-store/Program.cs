using Dsc.Web.Models;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Eureka;
using Steeltoe.Extensions.Configuration.Placeholder;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddPlaceholderResolver();
builder.WebHost.AddServiceDiscovery(options => options.UseEureka());

var app = builder.Build();
app.MapPost("/sel-brand", (Dictionary<string, string> arg) => new Dictionary<string, string> { { "brand", "Hugehard" } });
app.MapPost("/sel-mod", (Dictionary<string, string> arg) => new Dictionary<string, string> { { "length", "2.0" }, { "model", "New Standard" } });
app.MapPost("/query-price", (Dictionary<string, string> arg) => new Dictionary<string, string> { { "price", "399" } });
app.Run();
