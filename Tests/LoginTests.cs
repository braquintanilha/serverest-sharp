using Bogus;
using ServeRestSharp.Requests;
using ServeRestSharp.Responses.Login;
using ServeRestSharp.Services;
using ServeRestSharp.Support;

namespace Tests.ServeRestSharp;

[TestFixture, Category("Login")]
[Parallelizable]
public class LoginTests
{
    [Test, Description("Should login sucessfully with valid credentials")]
    public async Task SuccessfullyLogin()
    {
        // Arrange
        var user = await Commands.CreateRandomUser();
        var payload = new PostLoginBody { Email = user.Email, Password = user.Password };

        // Act
        var response = await LoginServices.PostLogin(payload);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        var body = JsonConvert.DeserializeObject<PostLoginSuccessfullyResponse>(response?.Content!);
        body?.Message.Should().Be("Login realizado com sucesso");
        body?.Authorization.Should().Contain("Bearer");
    }

    [Test, Description("Should not login with invalid credentials")]
    public async Task InvalidLogin()
    {
        // Arrange
        var faker = new Faker();
        var payload = new PostLoginBody { Email = faker.Internet.Email(), Password = faker.Internet.Password() };

        // Act
        var response = await LoginServices.PostLogin(payload);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
        var body = JsonConvert.DeserializeObject<PostLoginInvalidResponse>(response?.Content!);
        body?.Message.Should().Be("Email e/ou senha inválidos");
    }
}
