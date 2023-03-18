using Bogus;
using ServeRestSharp.Requests;
using ServeRestSharp.Responses.Login;
using ServeRestSharp.Responses.Products;
using ServeRestSharp.Responses.Users;
using ServeRestSharp.Services;

namespace ServeRestSharp.Support;

public static class Commons
{
    private static readonly Faker _faker = new Faker();

    public static async Task<string?> LoginWithAdmin()
    {
        var payload = new PostLoginBody("fulano@qa.com", "teste");
        var response = await LoginServices.PostLogin(payload);
        var body = JsonConvert.DeserializeObject<PostLoginSuccessfullyResponse>(response.Content!);
        return body?.Authorization;
    }

    public static async Task<User> CreateRandomUser()
    {
        var createUserPayload = new PostUserBody(
            _faker.Name.FirstName(),
            _faker.Internet.Email(),
            _faker.Internet.Password());

        var response = await UsersServices.PostUser(createUserPayload);
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        var userId = JsonConvert.DeserializeObject<PostUserSuccessfullyResponse>(response.Content!)?.Id;

        return new User
        {
            Name = createUserPayload.Name,
            Email = createUserPayload.Email,
            Password = createUserPayload.Password,
            Administrator = createUserPayload.Administrator,
            Id = userId
        };
    }

    public static async Task<Product> CreateRandomProduct()
    {
        var token = await LoginWithAdmin();
        var createProductPayload = new PostProductBody(
            _faker.Commerce.ProductName(),
            _faker.Random.Int(min: 0, max: 1000),
            _faker.Commerce.ProductDescription(),
            _faker.Random.Int(min: 0, max: 1000));

        var response = await ProductsServices.PostProduct(createProductPayload, token!);
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        var productId = JsonConvert.DeserializeObject<PostProductsSuccessfullyResponse>(response.Content!)?.Id;

        return new Product
        {
            Name = createProductPayload.Name,
            Price = createProductPayload.Price,
            Description = createProductPayload.Description,
            Quantity = createProductPayload.Quantity,
            Id = productId
        };
    }
}
