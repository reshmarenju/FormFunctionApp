global using Microsoft.Azure.WebJobs;
global using Microsoft.Extensions.Logging;
global using Microsoft.EntityFrameworkCore;
global using System;
global using System.Linq;
global using System.Xml.Linq;
global using System.Net.Http;
global using System.Collections.Generic;
global using System.Threading.Tasks;
using AutoMapper;


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
       // string connectionString = "Server=localhost\\SQLEXPRESS;Database=GeoPerform-UAT;Trusted_Connection=True;TrustServerCertificate=True";
        string connectionString = "Server=gp-prod2-sqlserver.database.windows.net;Initial Catalog=gp-prod2-db;Persist Security Info=False;User ID=gp-prod2-user;Password=Gt56@uj&hn676llOp;Encrypt=True;TrustServerCertificate=True;";

        builder.Services.AddDbContext<DataContext>(
            options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));

        string geoFormsConnectionString = "Server=localhost\\SQLEXPRESS;Database=GeoFormsBackup;Trusted_Connection=True;TrustServerCertificate=True";
        //"Default": "Server=gp-prod2-sqlserver.database.windows.net;Initial Catalog=gp-prod2-db;Persist Security Info=False;User ID=gp-prod2-user;Password=Gt56@uj&hn676llOp;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;"

        builder.Services.AddDbContext<GeoFormsDbContext>(options => options.UseSqlServer(geoFormsConnectionString));

        // Configure AutoMapper
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(Startup).Assembly); // Add mappings from the assembly
                                                   // Add more CreateMap calls if you have additional mappings
        });
        IMapper mapper = mapperConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);

        builder.Services.AddTransient<IFormsIngestionService, FormsIngestionService>();
    }
}