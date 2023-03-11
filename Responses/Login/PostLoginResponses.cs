namespace ServeRestSharp.Responses.Login;

public class PostLoginSuccessfullyResponse
{
    [JsonProperty("message")]
    public string? Message { get; set; }

    [JsonProperty("authorization")]
    public string? Authorization { get; set; }
}

public class PostLoginInvalidResponse
{
    [JsonProperty("message")]
    public string? Message { get; set; }
}
