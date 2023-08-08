global using Microsoft.Azure.WebJobs;
global using Microsoft.Extensions.Logging;
global using Microsoft.EntityFrameworkCore;
global using System;
global using System.Linq;
global using System.Xml.Linq;
global using System.Net.Http;
global using System.Collections.Generic;
global using System.Threading.Tasks;



using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using FormFunctionApp.Data;
using FormFunctionApp.Services.FormsIngestionService;

[assembly: FunctionsStartup(typeof(FormFunctionApp.Startup))]
namespace FormFunctionApp;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=GeoPerform-UAT;Trusted_Connection=True;TrustServerCertificate=True";
        builder.Services.AddDbContext<DataContext>(
          options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));
        string geoFormsConnectionString = "Server=localhost\\SQLEXPRESS;Database=GeoFormsBackup;Trusted_Connection=True;TrustServerCertificate=True";
        builder.Services.AddDbContext<GeoFormsDbContext>(options => options.UseSqlServer(geoFormsConnectionString));


        builder.Services.AddTransient<IFormsIngestionService,FormsIngestionService>();
    }
}
