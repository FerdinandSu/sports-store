using Dsc.Web.Models;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Eureka;
using Steeltoe.Extensions.Configuration.Placeholder;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddPlaceholderResolver();
builder.WebHost.AddServiceDiscovery(options => options.UseEureka());

var app = builder.Build();
app.MapPost("/shoe-size-convert", (Dictionary<string, string> arg) => new Dictionary<string, string> { { "size",
    (double.Parse(arg["length"]) switch
    {
        >=220 and <225 =>34 ,
        <230=>35,
        <235=>37,
        <240=>38,
        <245=>39,
        <250=>40,
        <255=>41,
        <260=>42,
        <265=>43,
        <270=>44,
        _=> 45
    }).ToString()}});
app.Run();
