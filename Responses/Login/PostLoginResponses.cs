namespace ServeRestSharp.Responses.Login;

public class PostLoginSuccessfullyResponse
{
    public string? Message { get; set; }
    public string? Authorization { get; set; }
}

public class PostLoginInvalidResponse
{
    public string? Message { get; set; }
}