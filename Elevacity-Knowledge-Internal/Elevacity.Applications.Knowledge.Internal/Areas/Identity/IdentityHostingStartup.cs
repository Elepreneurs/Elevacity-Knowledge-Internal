using System;
using Elevacity.UI.Internal.Areas.Identity.Data;
using Elevacity.UI.Internal.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Elevacity.UI.Internal.Areas.Identity.IdentityHostingStartup))]
namespace Elevacity.UI.Internal.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ElevacityInternalContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ElevacityInternalContextConnection")));

                services.AddDefaultIdentity<ElevacityInternalUser>()
                    .AddEntityFrameworkStores<ElevacityInternalContext>();
            });
        }
    }
}