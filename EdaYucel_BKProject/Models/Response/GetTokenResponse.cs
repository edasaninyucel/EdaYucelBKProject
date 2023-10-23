using System.Text.Json.Serialization;

namespace EdaYucel_BKProject.Models.Response;

public class GetTokenResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }

    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }

    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }
    
    [JsonPropertyName("tenant_id")]
    public int TenantId { get; set; }
    
}