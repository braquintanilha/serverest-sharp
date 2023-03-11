using ServeRestSharp.Responses.Users;
using ServeRestSharp.Services;
using ServeRestSharp.Support;

namespace ServeRestSharp.Tests;

[TestFixture, Category("Users")]
[Parallelizable]
public class UsersTests
{
    [Test, Description("Should return a user's data")]
    public async Task GetUser()
    {
        // Arrange
        var resGetList = await UsersServices.GetUserList();
        var userId = JsonConvert.DeserializeObject<GetUsersSuccessfully>(resGetList.Content!)?.Usuarios?[0]._Id!;

        // Act
        var response = await UsersServices.GetUserById(userId);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        var body = JsonConvert.DeserializeObject<GetUsersSuccessfully>(response.Content!);
        body?.Usuarios![0].Nome.Should().Be("Fulano da Silva");
        body?.Usuarios![0].Email.Should().Be("fulano@qa.com");
        body?.Usuarios![0].Password.Should().Be("teste");
        body?.Usuarios![0].Administrador.Should().Be("true");
    }

    [Test, Description("Should create a user")]
    public async Task CreateUser()
    {
        // Arrange
        var createdUser = await Commands.CreateRandomUser();

        // Act
        var response = await UsersServices.GetUserById(createdUser._Id!);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        var user = JsonConvert.DeserializeObject<GetUsersSuccessfully>(response.Content!)?.Usuarios![0];
        user?.Nome.Should().Be(createdUser?.Nome);
        user?.Email.Should().Be(createdUser?.Email);
        user?.Password.Should().Be(createdUser?.Password);
        user?.Administrador.Should().Be(createdUser?.Administrador);
    }
}
