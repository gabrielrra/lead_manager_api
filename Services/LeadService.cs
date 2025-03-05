using lead_manager.Models;
using lead_manager.Repositories;

namespace lead_manager.Services;

public class LeadService : ILeadService
{
  private readonly ILeadRepository _leadRepository;

  public LeadService(ILeadRepository leadRepository)
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
}
