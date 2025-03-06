using Microsoft.EntityFrameworkCore;
using lead_manager.Models;

namespace lead_manager.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }

  public DbSet<Lead> Leads { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder
        .UseSeeding((context, _) =>
        {
          var leadCount = context.Set<Lead>().Count();
          if (leadCount == 0)
          {
            context.Set<Lead>().AddRange(
              new Lead
              {
                Name = "John Doe",
                Location = "New York",
                Category = "Plumbing",
                Description = "Bathroom remodeling project",
                CreatedAt = DateTime.Now,
                JobId = "JOB-2023-001",
                Price = 2500,
                Email = "john.doe@email.com",
                Phone = "123-456-7890",
                Status = LeadStatus.Invited
              },
              new Lead
              {
                Name = "Jane Smith",
                Location = "Los Angeles",
                Category = "Electrical",
                Description = "Home rewiring project",
                CreatedAt = DateTime.Now,
                JobId = "JOB-2023-002",
                Price = 1800,
                Email = "jane.smith@email.com",
                Phone = "123-456-7890",
                Status = LeadStatus.Invited
              }
            );
            context.SaveChanges();
          }
        });
}
