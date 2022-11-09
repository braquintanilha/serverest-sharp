using ServeRestSharp.Requests;

namespace ServeRestSharp.Services;

public static class LoginServices
{
    private static readonly RestClient client = new ("https://serverest.dev");

    public static async Task<RestResponse> PostLogin(string username, string password)
    {
        var body = new PostLoginBody { Email = username, Password = password };

        var request = new RestRequest("login")
            .AddJsonBody(body);

        return await client.ExecutePostAsync(request);
    }
}
