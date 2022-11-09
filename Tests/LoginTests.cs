using ServeRestSharp.Responses.Login;
using ServeRestSharp.Services;

namespace Tests.ServeRestSharp;

[TestFixture, Category("Login")]
public class LoginTests
{
    [SetUp]
    public void SetUp()
    {
        // TODO: Creates a user on setup
    }

    [Test, Description("Should login sucessfully with valid credentials")]
    public async Task SuccessfullyLogin()
    {
        // Arrange 
        var email = "fulano@qa.com"; var password = "teste";

        // Act
        var response = await LoginServices.PostLogin(email, password);

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
        var email = faker.Internet.Email(); var password = faker.Internet.Password();

        // Act
        var response = await LoginServices.PostLogin(email, password);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
        var body = JsonConvert.DeserializeObject<PostLoginInvalidResponse>(response?.Content!);
        body?.Message.Should().Be("Email e/ou senha inválidos");
    }
}
