using FormFunctionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormFunctionApp.Data
{
    public class GeoFormsDbContext : DbContext
    {
        public GeoFormsDbContext(DbContextOptions<GeoFormsDbContext> options)
            : base(options)
        {
        }

        // Add DbSet properties for your models representing tables in the GeoForms database
        // For example:
        // public DbSet<GeoForm> GeoForms { get; set; }
         public DbSet<SubmittedForm> AppSubmittedForms { get; set; }
        // ...
    }
}
