using System;
using System.ComponentModel.DataAnnotations;

namespace lead_manager.Models;

public class Lead
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public string Location { get; set; }
    
    public string Category { get; set; }
    
    public string Description { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public string JobId { get; set; }
    
    public decimal? Price { get; set; }
}
