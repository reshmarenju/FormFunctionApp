using FormFunctionApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FormFunctionApp.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    //public DbSet<VeslinkForm> VeslinkForms { get; set; }
    public DbSet<Form> Forms { get; set; }
    public DbSet<Scrubber> Scrubbers { get; set; }
    public DbSet<ScrubberRow> ScrubberRows { get; set; }
    public DbSet<BerthingUnberthingDetailsRow> BerthingUnberthingDetailsRows { get; set; }
    public DbSet<Upcoming> Upcomings { get; set; }
    public DbSet<UpcomingPort> UpcomingPorts { get; set; }
    public DbSet<EventROBsRow> EventROBsRows { get; set; }
    public DbSet<Robs> Robs { get; set; }
    public DbSet<Rob> Rob { get; set; }
    public DbSet<Allocation> Allocations { get; set; }
    public DbSet<BerthingUnberthingDetails> BerthingUnberthingDetails { get; set; }
    public DbSet<BerthUnberthdetailsRow> BerthUnberthdetailsRows { get; set; }
    public DbSet<FuelsRows> FuelsRows { get; set; }
    public DbSet<FormPortActivities> FormPortActivities { get; set; }
  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define SFPM_Form_Id as the primary key for the Forms table
        modelBuilder.Entity<Form>()
            .HasKey(f => f.SFPM_Form_Id);
    }
}
