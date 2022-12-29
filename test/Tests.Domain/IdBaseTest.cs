using NUnit.Framework;
using Synthesizer.Domain.Entities.Ids;

namespace Tests.Abstractions;

public class IdBaseTest
{
    [Test]
    public void Equals_WithDifferentIdTypes_ShouldReturnFalse()
    {
        // Arrange
        var firstId = new SynthesizerId();
        var secondId = new OscillatorId();

        // Act
        var actual = firstId == secondId;

        // Assert
        Assert.IsFalse(actual);
    }

    [Test]
    public void Equals_WithDifferentIdTypesWithSameId_ShouldReturnFalse()
    {
        // Arrange
        const string sharedId = "Shared Id";
        var firstId = new SynthesizerId(sharedId);
        var secondId = new OscillatorId(sharedId);

        // Act
        var actual = firstId == secondId;

        // Assert
        Assert.IsFalse(actual);
    }

    # region SynthesizerId

    [Test]
    public void Equals_SynthesizersWithDifferentIds_ShouldReturnFalse()
    {
        // Arrange
        var firstId = new SynthesizerId();
        var secondId = new SynthesizerId();

        // Act
        var actual = firstId == secondId;

        // Assert
        Assert.IsFalse(actual);
    }

    [Test]
    public void Equals_SynthesizersWithSameId_ShouldReturnTrue()
    {
        // Arrange
        const string sharedId = "Shared Id";
        var firstId = new SynthesizerId(sharedId);
        var secondId = new SynthesizerId(sharedId);

        // Act
        var actual = firstId == secondId;

        // Assert
        Assert.IsTrue(actual);
    }

    # endregion

    # region OscillatorId

    [Test]
    public void Equals_OscillatorsWithDifferentIds_ShouldReturnFalse()
    {
        // Arrange
        var firstId = new OscillatorId();
        var secondId = new OscillatorId();

        // Act
        var actual = firstId == secondId;

        // Assert
        Assert.IsFalse(actual);
    }

    [Test]
    public void Equals_OscillatorsWithSameId_ShouldReturnTrue()
    {
        // Arrange
        const string sharedId = "Shared Id";
        var firstId = new OscillatorId(sharedId);
        var secondId = new OscillatorId(sharedId);

        // Act
        var actual = firstId == secondId;

        // Assert
        Assert.IsTrue(actual);
    }

    # endregion
}