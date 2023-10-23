using System.Text.Json.Serialization;

namespace EdaYucel_BKProject.Models.Response;

public class CompanyListResponse
{
    [JsonPropertyName("Key")]
    public int Key { get; set; }
    [JsonPropertyName("ScanStatus")]
    public string ScanStatus { get; set; }
    
}