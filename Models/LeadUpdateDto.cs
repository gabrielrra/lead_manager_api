using System.Text.Json.Serialization;
namespace lead_manager.Models;

public class LeadUpdateDto
{
  [JsonPropertyName("status")]
  public int Status { get; set; }
}
