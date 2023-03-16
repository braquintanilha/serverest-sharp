using RestSharp;
using ServeRestSharp.Requests;

namespace ServeRestSharp.Services;

public static class ProductsServices
{
    private static readonly RestClient _client = new ("https://serverest.dev");

    public static async Task<RestResponse> GetProductsList()
    {
        var request = new RestRequest("produtos");

        return await _client.ExecuteGetAsync(request);

    }

    public static async Task<RestResponse> GetProductById(string productId)
    {
        var request = new RestRequest($"produtos/{productId}");

        return await _client.ExecuteGetAsync(request);

    }

    public static async Task<RestResponse> PostProduct(PostProductBody body, string token)
    {
        var request = new RestRequest($"produtos")
            .AddHeader("Authorization", token)
            .AddBody(body);

        return await _client.ExecutePostAsync(request);

    }
}
