using System.Text.Json.Serialization;

namespace EdaYucel_BKProject.Models.Request;

public class EcosystemDeleteRequest
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}