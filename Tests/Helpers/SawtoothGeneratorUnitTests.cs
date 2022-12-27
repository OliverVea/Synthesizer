using System.Collections;
using Synthesizer.Services.Helpers.WaveformGenerators;

namespace Tests.Helpers;

public class SawtoothGeneratorUnitTests
{
    private const double ComparerAccuracy = 0.0001;
    private readonly IComparer _comparer = new WaveformComparer(ComparerAccuracy);
    private readonly SawtoothGenerator _sut = new();

    [Test]
    public void GenerateSamples_ValidParameters_CorrectWaveIsGenerated()
    {
        // Arrange
        var samples = new double[9];
        const double samplingFrequency = 1;
        const double waveAmplitude = 2;
        const double waveFrequency = 0.25;
        const double offset = 0;

        // Act
        _sut.GenerateSamples(samples, samples.Length, samplingFrequency, waveAmplitude, waveFrequency, offset);
        
        // Assert
        var expected = new[] { 0, 0.5, 1.0, 1.5, 0.0, 0.5, 1.0, 1.5, 0.0 };
        CollectionAssert.AreEqual(expected, samples, _comparer);
    }

    [Test]
    public void GenerateSamples_WithOffset_CorrectWaveIsGenerated()
    {
        // Arrange
        var samples = new double[9];
        const double samplingFrequency = 1;
        const double waveAmplitude = 2;
        const double waveFrequency = 0.25;
        const double offset = 0.1;

        // Act
        _sut.GenerateSamples(samples, samples.Length, samplingFrequency, waveAmplitude, waveFrequency, offset);
        
        // Assert
        var expected = new[] { 0.05, 0.55, 1.05, 1.55, 0.05, 0.55, 1.05, 1.55, 0.05 };
        CollectionAssert.AreEqual(expected, samples, _comparer);
    }

    [Test]
    public void GenerateSamples_WithNegativeOffset_CorrectWaveIsGenerated()
    {
        // Arrange
        var samples = new double[9];
        const double samplingFrequency = 1;
        const double waveAmplitude = 2;
        const double waveFrequency = 0.25;
        const double offset = -0.1;

        // Act
        _sut.GenerateSamples(samples, samples.Length, samplingFrequency, waveAmplitude, waveFrequency, offset);
        
        // Assert
        var expected = new[] { 1.95, 0.45, 0.95, 1.45, 1.95, 0.45, 0.95, 1.45, 1.95 };
        CollectionAssert.AreEqual(expected, samples, _comparer);
    }

    [Test]
    public void GenerateSamples_HighOffset_CorrectWaveIsGenerated()
    {
        // Arrange
        var samples = new double[9];
        const double samplingFrequency = 1;
        const double waveAmplitude = 2;
        const double waveFrequency = 0.25;
        const double offset = 1e10 + 0.1;

        // Act
        _sut.GenerateSamples(samples, samples.Length, samplingFrequency, waveAmplitude, waveFrequency, offset);
        
        // Assert
        var expected = new[] { 0.05, 0.55, 1.05, 1.55, 0.05, 0.55, 1.05, 1.55, 0.05 };
        CollectionAssert.AreEqual(expected, samples, _comparer);
    }
}