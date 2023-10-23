using System.Text.Json.Serialization;

namespace EdaYucel_BKProject.Models.Request;

public class CompanySearchRequest
{
    [JsonPropertyName("GenericSearchText")]
    public string GenericSearchText { get; set; }
    
    [JsonPropertyName("EcosystemIds")]
    public int EcosystemIds { get; set; }
  
}