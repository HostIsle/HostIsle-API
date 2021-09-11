using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(HostIsle.Web.Hotels.Areas.Identity.IdentityHostingStartup))]

namespace HostIsle.Web.Hotels.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}