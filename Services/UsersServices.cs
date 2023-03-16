using RestSharp;
using ServeRestSharp.Requests;

namespace ServeRestSharp.Services;

public static class UsersServices
{
    private static readonly RestClient _client = new ("https://serverest.dev");

    public static async Task<RestResponse> GetUserList()
    {
        var request = new RestRequest("usuarios");

        return await _client.ExecuteGetAsync(request);
    }

    public static async Task<RestResponse> GetUserById(string userId)
    {
        var request = new RestRequest($"usuarios/{userId}");

        return await _client.ExecuteGetAsync(request);
    }

    public static async Task<RestResponse> PostUser(PostUserBody body)
    {
        var request = new RestRequest("usuarios")
            .AddBody(body);

        return await _client.ExecutePostAsync(request);
    }

    public static async Task<RestResponse> DeleteUser(string? id)
    {
        var request = new RestRequest($"usuarios/${id}");

        return await _client.DeleteAsync(request);
    }
}
