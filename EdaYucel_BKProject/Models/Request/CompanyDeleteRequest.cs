using System.Text.Json.Serialization;

namespace EdaYucel_BKProject.Models.Request;

public class CompanyDeleteRequest
{
    [JsonPropertyName("id")]
    public int CompanyId { get; set; }
    
    [JsonPropertyName("EcosystemId")]
    public int EcosystemId { get; set; }
  
}