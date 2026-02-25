using Bunit;
using Xunit;

using Models;
using BlazorWebApp.Components;

namespace BlazorWebAppTests.Components;

public class ProductCardTests : BunitContext // BunitContext is the class that allows us to create UI components for testing
{
    [Fact]
    public void ProductCard_Renders_Product_Data_Correctly()
    {
        // Arrange

        int expectedId = 1;
        string expectedName = "Test product";
        double expectedPrice = 999.99;

        // Renders a component, using a parameterBuilder with lambda expression
        var cut = Render<ProductCard>(parameters => parameters
            .Add(p => p.Id, expectedId)
            .Add(p => p.Name, expectedName)
            .Add(p => p.Price, expectedPrice)
        );


        cut.Find("h1").MarkupMatches($"<h1>{expectedName}</h1>");
        cut.FindAll("p")[0].MarkupMatches($"<p>Id: {expectedId}</p>");
        cut.FindAll("p")[1].MarkupMatches($"<p>Price: {expectedPrice}</p>");
    }
}
