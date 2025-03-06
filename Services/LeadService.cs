using lead_manager.Models;
using lead_manager.Repositories;
using Bogus;

namespace lead_manager.Services;

public class LeadService
{
  private readonly LeadRepository _leadRepository;

  public LeadService(LeadRepository leadRepository)
  {
    _leadRepository = leadRepository;
  }

  public async Task<IEnumerable<Lead>> GetAllLeadsAsync()
  {
    return await _leadRepository.GetAllAsync();
  }

  public async Task<Lead?> GetLeadByIdAsync(int id)
  {
    return await _leadRepository.GetByIdAsync(id);
  }

  public async Task<Lead> CreateLeadAsync(Lead lead)
  {
    lead.CreatedAt = DateTime.UtcNow;
    return await _leadRepository.AddAsync(lead);
  }

  public async Task UpdateLeadAsync(Lead lead)
  {
    await _leadRepository.UpdateAsync(lead);
  }

  public async Task DeleteLeadAsync(int id)
  {
    await _leadRepository.DeleteAsync(id);
  }

  public async Task GenerateFakeLeads(int quantity)
  {
    var faker = new Faker<Lead>()
        .RuleFor(l => l.Name, f => f.Name.FullName())
        .RuleFor(l => l.Phone, f => f.Phone.PhoneNumber())
        .RuleFor(l => l.Email, (f, l) => f.Internet.Email(l.Name))
        .RuleFor(l => l.Location, f => f.Address.City())
        .RuleFor(l => l.Category, f => f.Commerce.Department())
        .RuleFor(l => l.Description, f => f.Lorem.Paragraph())
        .RuleFor(l => l.CreatedAt, f => f.Date.Past())
        .RuleFor(l => l.JobId, f => f.Random.Int())
        .RuleFor(l => l.Price, f => f.Random.Int(10000, 100000))
        .RuleFor(l => l.Status, f => LeadStatus.Invited);

    var fakeLeads = faker.Generate(quantity);
    await _leadRepository.AddBatchAsync(fakeLeads);
  }
}
