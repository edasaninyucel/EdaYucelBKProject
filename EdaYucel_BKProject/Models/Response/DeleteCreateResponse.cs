using System.Text.Json.Serialization;

namespace EdaYucel_BKProject.Models.Response;

public class DeleteCreateResponse
{
    [JsonPropertyName("CompanyId")]
    public string CompanyId { get; set; }
    
    [JsonPropertyName("EcosystemId")]
    public string EcosystemId { get; set; }
    
}