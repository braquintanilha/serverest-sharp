﻿using RestSharp;
using ServeRestSharp.Requests;

namespace ServeRestSharp.Services;

public static class LoginServices
{
    private static readonly RestClient _client = new ("https://serverest.dev");

    public static async Task<RestResponse> PostLogin(PostLoginBody body)
    {
        
        var request = new RestRequest("login")
            .AddBody(body);

        return await _client.ExecutePostAsync(request);
    }
}
