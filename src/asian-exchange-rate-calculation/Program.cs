using Dsc.Web.Models;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Eureka;
using Steeltoe.Extensions.Configuration.Placeholder;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddPlaceholderResolver();
builder.WebHost.AddServiceDiscovery(options => options.UseEureka());

var app = builder.Build();
app.MapPost("/usd2cny",
    (Dictionary<string, string> arg) => new Dictionary<string, string>
        {{"cny", (double.Parse(arg["usd"]) * 6.7384).ToString()}});
app.MapPost("/cny2usd", (Dictionary<string,string> arg) =>  new Dictionary<string,string>{{"usd", (double.Parse(arg["cny"]) * 0.1484).ToString() } });
app.MapPost("/jpy2usd", (Dictionary<string,string> arg) =>  new Dictionary<string,string>{{"usd", (double.Parse(arg["jpy"]) * 0.0072).ToString() } });
app.MapPost("/usd2jpy", (Dictionary<string,string> arg) =>  new Dictionary<string,string>{{"jpy", (double.Parse(arg["usd"]) * 139.123).ToString() } });
app.Run();
