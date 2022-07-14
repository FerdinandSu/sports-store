using Dsc.Web.Models;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Eureka;
using Steeltoe.Extensions.Configuration.Placeholder;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddPlaceholderResolver();
builder.WebHost.AddServiceDiscovery(options => options.UseEureka());

var app = builder.Build();
app.MapPost("/m2cm", (Dictionary<string,string> arg) =>  new Dictionary<string,string>{{"centimeter",
    (100.0*double.Parse(arg["meter"])).ToString()}});
app.MapPost("/cm2m", (Dictionary<string,string> arg) =>  new Dictionary<string,string>{{"meter", (0.01 * double.Parse(arg["centimeter"])).ToString() } });
app.MapPost("/g2kg", (Dictionary<string,string> arg) =>  new Dictionary<string,string>{{"kilogram", (0.001 * double.Parse(arg["gram"])).ToString() } });
app.MapPost("/kg2g", (Dictionary<string,string> arg) =>  new Dictionary<string,string>{{"gram", (1000.0 * double.Parse(arg["kilogram"])).ToString() } });
app.Run();
