using Dsc.Web.Models;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Eureka;
using Steeltoe.Extensions.Configuration.Placeholder;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddPlaceholderResolver();
builder.WebHost.AddServiceDiscovery(options => options.UseEureka());

var app = builder.Build();
app.MapPost("/cm2cun", (Dictionary<string,string> arg) =>  new Dictionary<string, string> { { "cun", (0.3*double.Parse(arg["centimeter"])).ToString()}});
app.MapPost("/cun2cm", (Dictionary<string,string> arg) =>  new Dictionary<string,string>{{"centimeter", (10.0/3 * double.Parse(arg["cun"])).ToString() } });
app.Run();
