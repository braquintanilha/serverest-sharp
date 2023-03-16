using Bogus;
using ServeRestSharp.Requests;
using ServeRestSharp.Responses.Products;
using ServeRestSharp.Services;
using ServeRestSharp.Support;

namespace ServeRestSharp.Tests;

[TestFixture]
[Category("Products")]
[Parallelizable]
public class ProductsTets
{

    [Test, Description("Should return a products's data")]
    public async Task GetProducts_Successfully()
    {
        // Arrange
        var responseList = await ProductsServices.GetProductsList();
        var productId = JsonConvert.DeserializeObject<GetProductsSuccessfullyResponse>(responseList.Content!)?.Products?[0].Id!;

        // Act
        var response = await ProductsServices.GetProductById(productId);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

    [Test, Description("Should create a product")]
    public async Task CreateProduct_Successfully()
    {
        // Arrange
        var faker = new Faker();
        var token = await Commands.LoginWithAdmin();
        var createProductPayload = new PostProductBody(
            name: faker.Commerce.ProductName(),
            price: faker.Random.Int(min: 0, max: 1000),
            description: faker.Commerce.ProductDescription(),
            quantity: faker.Random.Int(min: 0, max: 1000));

        // Act
        var response = await ProductsServices.PostProduct(createProductPayload, token!);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        var body = JsonConvert.DeserializeObject<PostProductsSuccessfullyResponse>(response.Content!);
        body?.Message.Should().Be("Cadastro realizado com sucesso");
        body?.Id.Should().NotBeNullOrEmpty();
    }
}
