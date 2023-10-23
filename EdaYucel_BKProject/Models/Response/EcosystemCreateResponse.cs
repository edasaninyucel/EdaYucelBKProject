using System.Text.Json.Serialization;

namespace EdaYucel_BKProject.Models.Response;

public class EcosystemCreateResponse
{
    [JsonPropertyName("EcosystemId")]
    public int EcosystemId { get; set; }
}