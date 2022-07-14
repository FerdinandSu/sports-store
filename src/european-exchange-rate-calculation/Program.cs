using Dsc.Web.Models;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Eureka;
using Steeltoe.Extensions.Configuration.Placeholder;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddPlaceholderResolver();
builder.WebHost.AddServiceDiscovery(options => options.UseEureka());

var app = builder.Build();
app.MapPost("/usd2nok", (Dictionary<string,string> arg) =>  new Dictionary<string,string>{{"nok", (double.Parse(arg["usd"]) * 10.203).ToString() } });
app.MapPost("/usd2eur", (Dictionary<string,string> arg) =>  new Dictionary<string,string>{ { "eur", (double.Parse(arg["usd"]) * 0.9959).ToString() } });
app.MapPost("/eur2nok", (Dictionary<string,string> arg) =>  new Dictionary<string,string>{ { "nok", (double.Parse(arg["eur"]) * 10.246).ToString() } });
app.MapPost("/eur2gbp", (Dictionary<string,string> arg) =>  new Dictionary<string,string>{{"gbp", (double.Parse(arg["eur"]) * 0.846).ToString() } });
app.Run();
