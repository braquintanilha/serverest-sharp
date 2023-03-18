using System.Collections.Generic;

namespace ServeRestSharp.Responses.Products;

public class Product
{
    [JsonProperty("nome")]
    public string? Name { get; set; }

    [JsonProperty("preco")]
    public int Price { get; set; }

    [JsonProperty("descricao")]
    public string? Description { get; set; }

    [JsonProperty("quantidade")]
    public int Quantity { get; set; }

    [JsonProperty("_id")]
    public string? Id { get; set; }
}

public class GetProductsSuccessfullyResponse
{
    [JsonProperty("quantidade")]
    public int QUantity { get; set; }

    [JsonProperty("produtos")]
    public List<Product>? Products { get; set; }
}
