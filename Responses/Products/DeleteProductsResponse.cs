namespace ServeRestSharp.Responses.Products;

public class DeleteProductsSuccessfullyResponse
{
    [JsonProperty("message")]
    public string? Message { get; set; }
}