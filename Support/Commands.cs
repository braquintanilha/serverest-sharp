using Bogus;
using ServeRestSharp.Requests;
using ServeRestSharp.Responses.Login;
using ServeRestSharp.Responses.Users;
using ServeRestSharp.Services;

namespace ServeRestSharp.Support;

public static class Commands
{
    public static async Task<string?> LoginWithAdmin()
    {
        var payload = new PostLoginBody("fulano@qa.com", "teste");
        var response = await LoginServices.PostLogin(payload);
        var body = JsonConvert.DeserializeObject<PostLoginSuccessfullyResponse>(response.Content!);
        return body?.Authorization;
    }

    public static async Task<User> CreateRandomUser()
    {
        var faker = new Faker();

        var createUserPayload = new PostUserBody(faker.Name.FirstName(), faker.Internet.Email(), faker.Internet.Password());

        var response = await UsersServices.PostUser(createUserPayload);
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        var userId = JsonConvert.DeserializeObject<PostUserSuccessfullyResponse>(response.Content!)?.Id;

        return new User
        {
            Nome = createUserPayload.Name,
            Email = createUserPayload.Email,
            Password = createUserPayload.Password,
            Administrador = createUserPayload.Administrator,
            Id = userId
        };
    }
}
