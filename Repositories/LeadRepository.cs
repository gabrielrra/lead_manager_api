using lead_manager.Data;
using lead_manager.Models;
using Microsoft.EntityFrameworkCore;

namespace lead_manager.Repositories;

public class LeadRepository : ILeadRepository
{
  private readonly AppDbContext _context;

  public LeadRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Lead>> GetAllAsync()
  {
    return await _context.Leads.ToListAsync();
  }

  public async Task<Lead?> GetByIdAsync(int id)
  {
    return await _context.Leads.FindAsync(id);
  }

  public async Task<Lead> AddAsync(Lead lead)
  {
    _context.Leads.Add(lead);
    await _context.SaveChangesAsync();
    return lead;
  }

  public async Task UpdateAsync(Lead lead)
  {
    _context.Entry(lead).State = EntityState.Modified;
    await _context.SaveChangesAsync();
  }

  public async Task DeleteAsync(int id)
  {
    var lead = await _context.Leads.FindAsync(id);
    if (lead != null)
    {
      _context.Leads.Remove(lead);
      await _context.SaveChangesAsync();
    }
  }
}
