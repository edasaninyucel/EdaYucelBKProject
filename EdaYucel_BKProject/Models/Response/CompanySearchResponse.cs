using System.Text.Json.Serialization;

namespace EdaYucel_BKProject.Models.Response;

public class CompanySearchResponse
{
    [JsonPropertyName("Key")]
    public int Key { get; set; }
    
}