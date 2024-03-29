using Bogus;
using ServeRestSharp.Requests;
using ServeRestSharp.Responses.Users;
using ServeRestSharp.Services;
using ServeRestSharp.Support;

namespace ServeRestSharp.Tests;

[TestFixture] 
[Category("Users")]
[Parallelizable]
public class UsersTests
{
    [Test, Description("Should return a user's data")]
    public async Task GetUsers_Success()
    {
        // Arrange
        var responseList = await UsersServices.GetUserList();
        var userId = JsonConvert.DeserializeObject<GetUsersSuccessfullyResponse>(responseList.Content!)?.Users?[0].Id!;

        // Act
        var response = await UsersServices.GetUserById(userId);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        var body = JsonConvert.DeserializeObject<GetUsersSuccessfullyResponse>(response.Content!);
    }

    [Test, Description("Should not return a user by invalid id")]
    public async Task GetUsers_NotFound()
    {
        // Arrange
        var userId = "Guid.NewGuid().ToString();";

        // Act
        var response = await UsersServices.GetUserById(userId);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
    }

    [Test, Description("Should create a user")]
    public async Task CreateUser_Success()
    {
        // Arrange
        var faker = new Faker();
        var createUserPayload = new PostUserBody(faker.Name.FirstName(), faker.Internet.Email(), faker.Internet.Password());

        // Act
        var response = await UsersServices.PostUser(createUserPayload);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        var body = JsonConvert.DeserializeObject<PostUserSuccessfullyResponse>(response.Content!);
        body?.Message.Should().Be("Cadastro realizado com sucesso");
        body?.Id.Should().NotBeNullOrEmpty();
    }

    [Test, Description("Should delete a user without registered cart")]
    public async Task DeleteUser_Success()
    {
        // Arrange
        var createdUser = await Commons.CreateRandomUser();

        // Act
        var response = await UsersServices.DeleteUser(createdUser.Id);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }
}
