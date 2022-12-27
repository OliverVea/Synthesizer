﻿using Moq;
using Synthesizer.Abstractions.Interfaces;
using Synthesizer.Abstractions.Models;
using Synthesizer.Services.Services;

namespace Tests.Services;

public class OscillatorServiceTest
{
    private Mock<IOscillatorStore> _mockedStore = null!;
    private IOscillatorService _sut = null!;

    [SetUp]
    public void SetupMocks()
    {
        _mockedStore = new Mock<IOscillatorStore>();
        _sut = new OscillatorService(_mockedStore.Object);
    }

    [Test]
    public void OscillatorService_WithInstantiatedServiceAndMocks_NotNull()
    {
        // Assert
        Assert.IsNotNull(_sut);
    }

    # region GetOscillator

    [Test]
    public void GetOscillator_WithAnyInput_CallsUnderlyingMethod()
    {
        // Arrange
        var id = new OscillatorId();

        // Act
        _sut.GetOscillator(id);

        // Assert
        _mockedStore.Verify(x => x.GetOscillator(id), Times.Once);
    }

    # endregion

    # region ListOscillators

    # endregion

    # region CreateOscillator

    # endregion

    # region DeleteOscillator

    # endregion

    # region UpdateOscillator

    # endregion
}