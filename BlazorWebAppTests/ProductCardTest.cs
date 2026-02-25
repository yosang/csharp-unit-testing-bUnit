using Bunit;
using Xunit;

using BlazorWebApp.Components;

namespace BlazorWebAppTests.Components;

public class ProductCardTests : BunitContext // BunitContext is the class that allows us to create UI components for testing
{
    [Fact]
    public void ProductCard_Renders_Product_Data_Correctly()
    {

        // Per documentation, we can also initiate a BunitContext and use it instead of inheriting from it, ctx.Render ...
        // using var ctx = new BunitContext();

        // Arrange
        int expectedId = 1;
        string expectedName = "Test product";
        double expectedPrice = 999.99;

        // Act
        // Renders a component, using a parameterBuilder with lambda expression
        var cut = Render<ProductCard>(parameters => parameters
            .Add(p => p.Id, expectedId)
            .Add(p => p.Name, expectedName)
            .Add(p => p.Price, expectedPrice)
        );

        // Assert - Assert syntax comes from xUnit, find, findall is from bUnit
        // cut is short for component under test (bUnit convention)
        Assert.Equal(expectedName, cut.Find("h1").TextContent);
        Assert.Equal($"Id: {expectedId}", cut.FindAll("p")[0].TextContent);
        Assert.Equal($"Price: {expectedPrice}", cut.FindAll("p")[1].TextContent);
    }
}
