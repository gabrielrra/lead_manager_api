using System.ComponentModel.DataAnnotations;

namespace lead_manager.Models;

public enum LeadStatus
{
    Invited,
    Accepted,
    Rejected
}

public class Lead
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    public required string Phone { get; set; }

    public required string Email { get; set; }

    public required string Location { get; set; }

    public required string Category { get; set; }

    public required string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public required int JobId { get; set; }

    public int Price { get; set; }

    public LeadStatus Status { get; set; }
}
