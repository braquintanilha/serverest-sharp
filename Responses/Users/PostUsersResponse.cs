namespace ServeRestSharp.Responses.Users;

public class PostUserSuccessfullyResponse
{
    [JsonProperty("message")]
    public string? Message { get; set; }

    [JsonProperty("_id")]
    public string? Id { get; set; }
}
