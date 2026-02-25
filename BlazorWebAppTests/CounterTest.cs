using Bunit;
using Xunit;
using BlazorWebApp.Components;

namespace BlazorWebAppTests.Components;
public class CounterTests: BunitContext
{
    [Fact]
    public void Counter_Increments_WhenButtonIsClicked()
    {
        // Arrange
        var cut = Render<Counter>();

        // Act
        cut.Find("button").Click();

        // Assert
        
        cut.MarkupMatches("""
        <h1>Counter</h1>
        <p>Count: 2</p>
        <button>Click me</button>
        """);
    }

}