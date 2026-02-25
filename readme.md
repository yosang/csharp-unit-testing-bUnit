# Testing Blazor Components with bUnit
## What is bUnit?

bUnit is a testing library for Blazor components.
It allows us to render components in a test context and verify their behavior and rendered markup.

It integrates naturally with xUnit.

# Installation
We add the NuGet package to our test project with `dotnet add package bunit`

# Usage

## Component
Assuming we the following component (`HelloComponent.razor`):
```c#
<h3>Hello @Name</h3>

@code {
    [Parameter]
    public string Name { get; set; } = string.Empty;
}
```

## Testing the component
```c#
using Bunit;
using Xunit;

public class HelloComponentTests : BunitTestContext
{
    [Fact]
    public void Component_ShouldRenderNameCorrectly()
    {
        // Arrange
        var name = "Yosmel";

        // Act
        var cut = Render<HelloComponent>(
            parameters => parameters.Add(p => p.Name, name)
        );

        // Assert
        cut.MarkupMatches("<h3>Hello Yosmel</h3>");
    }
}
```
# Key features
## BunitTestContext
`BunitTestContext` provides the test environment for rendering components.

Our testing class can inherit from it:
```c#
public class MyComponentTests : TestContext
```

## Render<T>()
Renders a Blazor component inside the test environment.
```c#
var cut = Render<MyComponent>();
```

## Finding Elements
We can query the rendered HTML:
```c#
cut.Find("h3");
cut.Find("button");
cut.Find("#my-id");
```

## Triggering Events
We can simulate user interactions:
```c#
cut.Find("button").Click();
cut.Find("input").Change("new value");
```

## Verifying Markup

Assertions:

- MarkupMatches()
- Find()
- FindAll()

```c#
cut.MarkupMatches("<p>Expected content</p>");
```

# Example
```c#
[Fact]
public void Counter_ShouldIncrement_WhenButtonClicked()
{
    // Arrange
    var cut = Render<Counter>();

    // Act
    cut.Find("button").Click();

    // Assert
    cut.MarkupMatches("""
        <p role="status">Current count: 1</p>
        <button>Click me</button>
    """);
}
```
