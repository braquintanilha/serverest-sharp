using System.Text.Json.Serialization;

namespace ServeRestSharp.Requests;

public class PostUserBody
{
    [JsonPropertyName("nome")]
    public string? Name { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("administrador")]
    public string? Administrator { get; set; }
}
