using Dsc.Web.Models;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Eureka;
using Steeltoe.Extensions.Configuration.Placeholder;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddPlaceholderResolver();
builder.WebHost.AddServiceDiscovery(options => options.UseEureka());

var app = builder.Build();
app.MapPost("/cm2inch", (Dictionary<string,string> arg) =>  new Dictionary<string,string>{{"inch", (double.Parse(arg["centimeter"])/2.54).ToString() } });
app.MapPost("/inch2cm", (Dictionary<string,string> arg) =>  new Dictionary<string,string>{{"centimeter", (double.Parse(arg["inch"]) * 2.54).ToString() } });
app.Run();
