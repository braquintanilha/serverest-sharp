using System.Text.Json.Serialization;

namespace ServeRestSharp.Requests;

public class PostProductBody
{
    [JsonPropertyName("nome")]
    public string? Name { get; set; }

    [JsonPropertyName("preco")]
    public decimal Price { get; set; }

    [JsonPropertyName("descricao")]
    public string? Description { get; set; }

    [JsonPropertyName("quantidade")]
    public int Quantity { get; set; }

    public PostProductBody(string name, decimal price, string description, int quantity)
    {
        Name = name;
        Price = price;
        Description = description;
        Quantity = quantity;
    }
}
