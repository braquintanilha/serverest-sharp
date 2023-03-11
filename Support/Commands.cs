using Bogus;
using ServeRestSharp.Requests;
using ServeRestSharp.Responses.Users;
using ServeRestSharp.Services;

namespace ServeRestSharp.Support;

public static class Commands
{
    public static async Task<Usuario> CreateRandomUser()
    {
        var faker = new Faker();

        var createUserPayload = new PostUserBody(faker.Name.FirstName(), faker.Internet.Email(), faker.Internet.Password(), "true");

        var response = await UsersServices.PostUser(createUserPayload);
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        var userId = JsonConvert.DeserializeObject<PostUserSuccessfullyResponse>(response.Content!)?._Id;

        return new Usuario
        {
            Nome = createUserPayload.Name,
            Email = createUserPayload.Email,
            Password = createUserPayload.Password,
            Administrador = createUserPayload.Administrator,
            _Id = userId
        };
    }
}
