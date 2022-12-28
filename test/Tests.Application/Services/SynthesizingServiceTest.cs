﻿using NUnit.Framework;
using Synthesizer.Application.Services;
using Synthesizer.Domain.Interfaces;

namespace Tests.Application.Services;

public class SynthesizingServiceTest
{
    private ISynthesizingService _sut = null!;

    [SetUp]
    public void SetupMocks()
    {
        _sut = new SynthesizingService();
    }

    [Test]
    public void SynthesizerConfigurationService_WithInstanceAndMocks_NotNull()
    {
        // Assert
        Assert.NotNull(_sut);
    }
}