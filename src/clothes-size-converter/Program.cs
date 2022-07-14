using Dsc.Web.Models;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Eureka;
using Steeltoe.Extensions.Configuration.Placeholder;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddPlaceholderResolver();
builder.WebHost.AddServiceDiscovery(options => options.UseEureka());

var app = builder.Build();
app.MapPost("/clothes-size-convert", (Dictionary<string,string> arg) =>  new Dictionary<string,string>{
{
    "size",
    double.Parse(arg["height"]) switch
    {
        >160 and <165=>"S",
        <170=>"M",
        <175=>"L",
        <180=>"XL",
        <185=>"XXL",
        <190=>"XXXL",
        _=>"XXXXL"
    }
}});
app.Run();
