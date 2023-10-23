using System.Text.Json.Serialization;

namespace EdaYucel_BKProject.Models.Request;

public class CompanyCreateRequest
{
    [JsonPropertyName("MainDomainValue")]
    public string MainDomainValue { get; set; }
    [JsonPropertyName("CompanyName")]
    public string CompanyName { get; set; }
    [JsonPropertyName("LicenseType")]
    public string LicenseType { get; set; }
    
    [JsonPropertyName("EcosystemId")]
    public string EcosystemId { get; set; }
    
    [JsonPropertyName("IsSubsidiary")]
    public string IsSubsidiary { get; set; }
    
    [JsonPropertyName("IsCloudProvider")]
    public string IsCloudProvider { get; set; }
    
    
}