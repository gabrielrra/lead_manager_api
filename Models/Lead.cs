using System.ComponentModel.DataAnnotations;

namespace lead_manager.Models;

public class Lead
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    public required string Location { get; set; }

    public required string Category { get; set; }

    public required string Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public required string JobId { get; set; }

    public int Price { get; set; }
}
