using Bunit;
using Xunit;
using BlazorWebApp.Components;

namespace BlazorWebAppTests.Pages;

public class HomePageTests : BunitContext
{
    [Fact]
    public void ProductPage_Shows_Products_Corretly()
    {
        // Arrange - bUnit will call OnInitialized automaticall, products list gets populated
        var cut = Render<Home>();

        // Act - Find all <li> elements (product names)
        var productItems = cut.FindAll("li");

        // Assert - Here we are using xUnit Assertion syntax
        Assert.Equal(3, productItems.Count);
        Assert.Equal("Laptop", productItems[0].TextContent);
    }
    
}