using System.Text.Json.Serialization;

namespace ServeRestSharp.Requests;

public class PostLoginBody
{
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    [JsonPropertyName("password")]
    public string? Password { get; set; }
}
