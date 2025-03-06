using System.Text.Json.Serialization;
namespace lead_manager.Models;

public class LeadGenerateFakeDataDto
{
  [JsonPropertyName("quantity")]
  public int Quantity { get; set; }
}
