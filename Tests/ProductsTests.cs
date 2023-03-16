using ServeRestSharp.Responses.Products;
using ServeRestSharp.Services;

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
}
