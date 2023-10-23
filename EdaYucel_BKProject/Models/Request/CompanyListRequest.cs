using System.Text.Json.Serialization;

namespace EdaYucel_BKProject.Models.Request;

public class CompanyListRequest
{
    [JsonPropertyName("Key")]
    public int Key { get; set; }
  
}