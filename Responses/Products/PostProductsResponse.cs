namespace ServeRestSharp.Responses.Products;

public class PostProductsSuccessfullyResponse
{
    [JsonProperty("message")]
    public string? Message { get; set; }

    [JsonProperty("_id")]
    public string? Id { get; set; }
}