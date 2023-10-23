using System.Text.Json.Serialization;

namespace EdaYucel_BKProject.Models.Request;

public class EcosystemCreateRequest
{
    [JsonPropertyName("EcosystemName")]
    public string EcosystemName { get; set; }
    
    [JsonPropertyName("EcosystemId")]
    public int EcosystemId { get; set; }
}