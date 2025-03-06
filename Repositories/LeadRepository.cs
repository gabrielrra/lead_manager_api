using lead_manager.Data;
using lead_manager.Models;
using Microsoft.EntityFrameworkCore;

namespace lead_manager.Repositories;

public class LeadRepository
{
  private readonly AppDbContext _context;

  public LeadRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Lead>> GetAllAsync(LeadStatus[] status, string sort = "desc")
  {
    var query = _context.Leads.AsQueryable();

    if (status != null && status.Length > 0)
    {
      query = query.Where(l => status.Contains(l.Status));
    }

    if (sort == "asc")
    {
      return await query.OrderBy(l => l.CreatedAt).ToListAsync();
    }
    return await query.OrderByDescending(l => l.CreatedAt).ToListAsync();
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

  public async Task AddBatchAsync(IEnumerable<Lead> leads)
  {
    _context.Leads.AddRange(leads);
    await _context.SaveChangesAsync();
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
