namespace ServeRestSharp.Requests;

public class PostUserBody
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Administrator { get; set; }
}
