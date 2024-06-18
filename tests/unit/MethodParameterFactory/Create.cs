﻿namespace Paraminter.Parameters;

using Microsoft.CodeAnalysis;

using Moq;

using System;

using Xunit;

public sealed class Create
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void NullSymbol_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidSymbol_ReturnsMethodParameter()
    {
        var result = Target(Mock.Of<IParameterSymbol>());

        Assert.NotNull(result);
    }

    private IMethodParameter Target(
        IParameterSymbol symbol)
    {
        return Fixture.Sut.Create(symbol);
    }
}