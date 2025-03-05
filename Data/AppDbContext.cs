using Microsoft.EntityFrameworkCore;
using lead_manager.Models;

namespace lead_manager.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }

  public DbSet<Lead> Leads { get; set; }
}
