using ServeRestSharp.Requests;
using ServeRestSharp.Services;

namespace ServeRestSharp.Support;

public static class Commands
{
    public static async Task<PostUserBody> CreateRandomUser()
    {
        var faker = new Faker();

        var createUserPayload = new PostUserBody
        {
            Name = faker.Name.FirstName(),
            Email = faker.Internet.Email(),
            Password = faker.Internet.Password(),
            Administrator = "true",
        };

        var response = await UsersServices.PostUser(createUserPayload);
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        return createUserPayload;
    }
}
