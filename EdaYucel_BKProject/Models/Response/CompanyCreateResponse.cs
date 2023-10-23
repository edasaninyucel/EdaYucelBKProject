using System.Text.Json.Serialization;

namespace EdaYucel_BKProject.Models.Response;

public class CompanyCreateResponse
{
    [JsonPropertyName("CompanyId")]
    public int CompanyId { get; set; }
    
    [JsonPropertyName("Key")]
    public string Key { get; set; }
    
    [JsonPropertyName("ScanStatus")]
    public string ScanStatus { get; set; }
    
    [JsonPropertyName("CompanyName")]
    public string CompanyName { get; set; }
    [JsonPropertyName("MainDomainValue")]
    public string MainDomainValue { get; set; }
    
    [JsonPropertyName("EcosystemId")]
    public int EcosystemId { get; set; }
    
    [JsonPropertyName("EcosystemName")]
    public string EcosystemName { get; set; }
    
}