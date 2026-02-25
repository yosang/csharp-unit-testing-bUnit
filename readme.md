# Project
In this project, we are testing our previous [Blazor Web App](https://github.com/yosang/csharp-blazor). We have extended it with a `Counter` component in order to test the click of a button on the UI with `bUnit`.

In summary, we are testing:
- `Home.razor` page lists `Products` correctly. 
- `ProductCard.razor` component renders correctly.
- `Counter.razor` component behaves as expected when the increment button is clicked.

## What is bUnit?

bUnit is a testing library for Blazor components.
It allows us to render components in a test context and verify their behavior and rendered markup.

It integrates naturally with xUnit.

# Installation
We add the NuGet package to our test project with `dotnet add package bunit`

# Usage

## Component
Assuming we have the following component (`HelloComponent.razor`):
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

public class HelloComponentTests : BunitContext
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
## BunitContext
`BunitContext` provides the test environment for rendering components.

Our testing class can inherit from it:
```c#
public class MyComponentTests : BunitContext
```

## Alternative: Creating a Context Manually
Instead of inheriting from BunitContext, we can instantiate it directly:

```c#
using var ctx = new BunitContext();

var cut = ctx.Render<HelloComponent>();
```

This is useful when:
- We prefer composition over inheritance
- We want isolated contexts per test

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
        <p>Current count: 1</p>
        <button>Click me</button>
    """);
}
```

# Important Notes
- `cut` stands for **Component Under Test** (bUnit convention).
- `Find()` and `FindAll()` asserton methods come from bUnit.
- `Assert.*` methods come from xUnit.
- `Render<T>()` renders the component and applies parameters via a builder used with lambda syntax.

# Usage
1. Clone the project with `git clone`.
2. Run tests with `dotnet test`

# Author
[Yosmel Chiang](https://github.com/yosang)