using System.Collections.Generic;

namespace ServeRestSharp.Responses.Products;

public class Product
{
    [JsonProperty("nome")]
    public string? Nome { get; set; }

    [JsonProperty("preco")]
    public int Preco { get; set; }

    [JsonProperty("descricao")]
    public string? Descricao { get; set; }

    [JsonProperty("quantidade")]
    public int Quantidade { get; set; }

    [JsonProperty("_id")]
    public string? Id { get; set; }
}

public class GetProductsSuccessfullyResponse
{
    [JsonProperty("quantidade")]
    public int Quantidade { get; set; }

    [JsonProperty("produtos")]
    public List<Product>? Products { get; set; }
}
