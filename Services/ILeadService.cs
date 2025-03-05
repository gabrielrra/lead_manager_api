using lead_manager.Models;

namespace lead_manager.Services;

public interface ILeadService
{
  Task<IEnumerable<Lead>> GetAllLeadsAsync();
  Task<Lead?> GetLeadByIdAsync(int id);
  Task<Lead> CreateLeadAsync(Lead lead);
  Task UpdateLeadAsync(Lead lead);
  Task DeleteLeadAsync(int id);
}
