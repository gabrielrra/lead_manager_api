using Microsoft.EntityFrameworkCore;
using lead_manager.Models;
using Bogus;

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
              new Faker<Lead>()
              .RuleFor(l => l.Name, f => f.Name.FullName())
              .RuleFor(l => l.Phone, f => f.Phone.PhoneNumber())
              .RuleFor(l => l.Email, (f, l) => f.Internet.Email(l.Name))
              .RuleFor(l => l.Location, f => f.Address.City())
              .RuleFor(l => l.Category, f => f.Commerce.Department())
              .RuleFor(l => l.Description, f => f.Lorem.Paragraph())
              .RuleFor(l => l.CreatedAt, f => f.Date.Past())
              .RuleFor(l => l.JobId, f => f.Random.Int(0))
              .RuleFor(l => l.Price, f => f.Random.Int(10000, 100000))
              .RuleFor(l => l.Status, f => LeadStatus.Invited)
              .Generate(10)
            );
            context.SaveChanges();
          }
        });
}
