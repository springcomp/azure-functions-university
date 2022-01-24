using System.Text.Json.Serialization;

public class GetTokenRequest
{
	[JsonPropertyName("client_id")]
	public string ClientId { get; set; }
	[JsonPropertyName("client_secret")]
	public string ClientSecret { get; set; }
	[JsonPropertyName("grant_type")]
	public string GrantType { get; set; } = "client_credentials";
	[JsonPropertyName("resource")]
	public string Resource { get; set; }
}