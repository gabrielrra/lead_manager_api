using lead_manager.Models;

namespace lead_manager.Repositories;

public interface ILeadRepository
{
  Task<IEnumerable<Lead>> GetAllAsync();
  Task<Lead?> GetByIdAsync(int id);
  Task<Lead> AddAsync(Lead lead);
  Task UpdateAsync(Lead lead);
  Task DeleteAsync(int id);
}
