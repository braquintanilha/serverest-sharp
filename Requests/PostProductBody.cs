using System.Text.Json.Serialization;

namespace ServeRestSharp.Requests;

public class PostProductBody
{
    [JsonPropertyName("nome")]
    public string? Name { get; set; }

    [JsonPropertyName("preco")]
    public int Price { get; set; }

    [JsonPropertyName("descricao")]
    public string? Description { get; set; }

    [JsonPropertyName("quantidade")]
    public int Quantity { get; set; }

    public PostProductBody(string name, int price, string description, int quantity)
    {
        Name = name;
        Price = price;
        Description = description;
        Quantity = quantity;
    }
}
