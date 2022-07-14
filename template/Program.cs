using Dsc.Web.Models;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Eureka;
using Steeltoe.Extensions.Configuration.Placeholder;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddPlaceholderResolver();
builder.WebHost.AddServiceDiscovery(options => options.UseEureka());

var app = builder.Build();
