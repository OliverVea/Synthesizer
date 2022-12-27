using AutoFixture;
using Moq;
using Synthesizer.Abstractions.Interfaces;
using Synthesizer.Abstractions.Models.Ids;
using Synthesizer.Abstractions.Models.Synthesizers;
using Synthesizer.Services.Services;

namespace Tests.Services;

public class SynthesizerServiceUnitTests : BaseUnitTest
{
    private Mock<ISynthesizerStore> _mockedStore = null!;
    private ISynthesizerService _sut = null!;

    [SetUp]
    public void SetupMocks()
    {
        _mockedStore = new Mock<ISynthesizerStore>();
        _sut = new SynthesizerService(_mockedStore.Object);
    }

    [Test]
    public void SynthesizerService_WithInstantiatedServiceAndMocks_NotNull()
    {
        // Assert
        Assert.NotNull(_sut);
    }

    # region DeleteSynthesizer

    [Test]
    public void DeleteSynthesizer_WithSynthesizerId_UnderlyingMethodIsCalled()
    {
        // Arrange
        var id = new SynthesizerId();

        // Act
        _sut.DeleteSynthesizer(id);

        // Assert
        _mockedStore.Verify(x => x.DeleteSynthesizer(id), Times.Once);
    }

    # endregion

    # region UpdateSynthesizer

    [Test]
    public void UpdateSynthesizer_WithNoChanges_UpdatesStoredEntity()
    {
        // Arrange
        var id = new SynthesizerId();
        var request = DataBuilder.UpdateSynthesizerRequest(id).Create();

        var synthesizerInformation = DataBuilder.SynthesizerInformation().Create();
        _mockedStore.Setup(x => x.GetSynthesizer(id)).Returns(synthesizerInformation);

        // Act
        _sut.UpdateSynthesizer(request);

        // Assert
        _mockedStore.Verify(x => x.SetSynthesizer(id, It.IsAny<SynthesizerInformation>()), Times.Once());
    }

    [Test]
    public void UpdateSynthesizer_WithInvalidId_ThrowsArgumentException()
    {
        // Arrange
        var id = new SynthesizerId();
        var request = DataBuilder.UpdateSynthesizerRequest(id).Create();

        _mockedStore.Setup(x => x.GetSynthesizer(id)).Returns((SynthesizerInformation?)null);

        // Act
        var error = Assert.Throws<ArgumentException>(() => _sut.UpdateSynthesizer(request));

        // Assert
        Assert.That(error?.ParamName, Is.EqualTo(nameof(request.SynthesizerId)));
    }

    [TestCaseSource(nameof(Amplitudes))]
    public void UpdateSynthesizer_NewMasterVolume_UpdatesStoredEntity(double masterVolume)
    {
        // Arrange
        var tolerance = DefaultDoubleTolerance();
        var id = new SynthesizerId();
        var request = DataBuilder.UpdateSynthesizerRequest(id)
            .With(x => x.MasterVolume, masterVolume).Create();

        var synthesizerInformation = DataBuilder.SynthesizerInformation().Create();
        _mockedStore.Setup(x => x.GetSynthesizer(id)).Returns(synthesizerInformation);

        // Act
        _sut.UpdateSynthesizer(request);

        // Assert
        _mockedStore.Verify(x => x.SetSynthesizer(id,
                It.Is<SynthesizerInformation>(y => Math.Abs(y.MasterVolume - masterVolume) < tolerance)),
            Times.Once());
    }

    [TestCaseSource(nameof(InvalidAmplitudes))]
    public void UpdateSynthesizer_WithInvalidMasterVolume_ThrowsValidationError(double invalidMasterVolume)
    {
        // Arrange
        var id = new SynthesizerId();
        var request = DataBuilder.UpdateSynthesizerRequest(id)
            .With(x => x.MasterVolume, invalidMasterVolume).Create();

        var synthesizerInformation = DataBuilder.SynthesizerInformation().Create();
        _mockedStore.Setup(x => x.GetSynthesizer(id)).Returns(synthesizerInformation);

        // Act
        var error = Assert.Throws<ArgumentException>(() => _sut.UpdateSynthesizer(request));

        // Assert
        Assert.That(error?.ParamName, Is.EqualTo(nameof(request)));
        Assert.IsTrue(error?.Message.Contains(nameof(request.MasterVolume)));
    }

    [Test]
    public void UpdateSynthesizer_NewDisplayName_UpdatesStoredEntity()
    {
        // Arrange
        var id = new SynthesizerId();
        var displayName = "New Display Name";
        var request = DataBuilder.UpdateSynthesizerRequest(id)
            .With(x => x.DisplayName, displayName).Create();

        var synthesizerInformation = DataBuilder.SynthesizerInformation().Create();
        _mockedStore.Setup(x => x.GetSynthesizer(id)).Returns(synthesizerInformation);

        // Act
        _sut.UpdateSynthesizer(request);

        // Assert
        _mockedStore.Verify(x => x.SetSynthesizer(id,
                It.Is<SynthesizerInformation>(y => y.DisplayName == displayName)),
            Times.Once());
    }

    # endregion

    # region ListSynthesizers

    [Test]
    public void ListSynthesizers_WithNoSynthesizers_EmptyListIsReturned()
    {
        // Arrange

        // Act
        var actual = _sut.ListSynthesizers();

        // Assert
        Assert.IsEmpty(actual);
    }

    [Test]
    public void ListSynthesizers_WithOneSynthesizer_IsListed()
    {
        // Arrange
        var synthesizers = new[]
        {
            DataBuilder.SynthesizerInformation().Create()
        };

        _mockedStore.Setup(x => x.ListSynthesizers()).Returns(synthesizers);

        // Act
        var actual = _sut.ListSynthesizers();

        // Assert
        CollectionAssert.AreEqual(synthesizers, actual);
    }

    [Test]
    public void ListSynthesizers_WithMultipleSynthesizer_AreListed()
    {
        // Arrange
        var synthesizers = new[]
        {
            DataBuilder.SynthesizerInformation().Create(),
            DataBuilder.SynthesizerInformation().Create(),
            DataBuilder.SynthesizerInformation().Create(),
            DataBuilder.SynthesizerInformation().Create(),
            DataBuilder.SynthesizerInformation().Create()
        };

        _mockedStore.Setup(x => x.ListSynthesizers()).Returns(synthesizers);

        // Act
        var actual = _sut.ListSynthesizers();

        // Assert
        CollectionAssert.AreEqual(synthesizers, actual);
    }

    # endregion

    #region GetSynthesizer

    [Test]
    public void GetSynthesizer_NoSynthesizers_NoneAreReturned()
    {
        // Arrange
        var id = new SynthesizerId();

        // Act
        var actual = _sut.GetSynthesizer(id);

        // Assert
        Assert.IsNull(actual);
    }

    [Test]
    public void GetSynthesizer_ExistingSynthesizer_IsReturned()
    {
        // Arrange
        var id = new SynthesizerId();
        var synthesizer = DataBuilder.SynthesizerInformation().Create();

        _mockedStore.Setup(x => x.GetSynthesizer(id)).Returns(synthesizer);

        // Act
        var actual = _sut.GetSynthesizer(id);

        // Assert
        Assert.That(synthesizer, Is.EqualTo(actual));
    }

    #endregion

    #region CreateSynthesizer

    [Test]
    public void CreateSynthesizer_DefaultSynthesizer_AddsSynthesizerToStoreOnce()
    {
        // Arrange
        var request = DataBuilder.CreateSynthesizerRequest().Create();

        // Act
        _sut.CreateSynthesizer(request);

        // Assert
        _mockedStore.Verify(x => x.SetSynthesizer(
            It.IsAny<SynthesizerId>(),
            It.IsAny<SynthesizerInformation>()), Times.Once);
    }

    [Test]
    public void CreateSynthesizer_NewSynthesizer_IdIsStoredAndReturned()
    {
        // Arrange
        var request = DataBuilder.CreateSynthesizerRequest().Create();

        // Act
        var expected = _sut.CreateSynthesizer(request);

        // Assert
        _mockedStore.Verify(x => x.SetSynthesizer(
            It.Is<SynthesizerId>(y => y == expected),
            It.IsAny<SynthesizerInformation>()));
    }

    [TestCaseSource(nameof(SampleRates))]
    public void CreateSynthesizer_WithSampleRate_SamplingRateIsStored(int sampleRate)
    {
        // Arrange
        var request = DataBuilder.CreateSynthesizerRequest()
            .With(x => x.SampleRate, sampleRate).Create();

        // Act
        _sut.CreateSynthesizer(request);

        // Assert
        _mockedStore.Verify(x => x.SetSynthesizer(
            It.IsAny<SynthesizerId>(),
            It.Is<SynthesizerInformation>(y => y.SampleRate == sampleRate)));
    }

    [TestCaseSource(nameof(InvalidSampleRates))]
    public void CreateSynthesizer_WithInvalidSampleRate_ThrowsValidationError(int sampleRate)
    {
        // Arrange
        var request = DataBuilder.CreateSynthesizerRequest()
            .With(x => x.SampleRate, sampleRate).Create();

        // Act
        var error = Assert.Throws<ArgumentException>(() => _sut.CreateSynthesizer(request));

        // Assert
        Assert.That(error?.ParamName, Is.EqualTo(nameof(request)));
        Assert.IsTrue(error?.Message.Contains(nameof(request.SampleRate)));
    }

    [TestCaseSource(nameof(Amplitudes))]
    public void CreateSynthesizer_WithMasterVolume_MasterVolumeIsStored(double masterVolume)
    {
        // Arrange
        var tolerance = DefaultDoubleTolerance(masterVolume);
        var request = DataBuilder.CreateSynthesizerRequest()
            .With(x => x.MasterVolume, masterVolume).Create();

        // Act
        _sut.CreateSynthesizer(request);

        // Assert
        _mockedStore.Verify(x => x.SetSynthesizer(
            It.IsAny<SynthesizerId>(),
            It.Is<SynthesizerInformation>(y => Math.Abs(y.MasterVolume - masterVolume) < tolerance)));
    }

    [TestCaseSource(nameof(InvalidAmplitudes))]
    public void CreateSynthesizer_WithInvalidMasterVolume_ThrowsValidationError(double invalidMasterVolume)
    {
        // Arrange
        var request = DataBuilder.CreateSynthesizerRequest()
            .With(x => x.MasterVolume, invalidMasterVolume).Create();

        // Act
        var error = Assert.Throws<ArgumentException>(() => _sut.CreateSynthesizer(request));

        // Assert
        Assert.That(error?.ParamName, Is.EqualTo(nameof(request)));
        Assert.IsTrue(error?.Message.Contains(nameof(request.MasterVolume)));
    }

    [Test]
    public void CreateSynthesizer_WithDisplayName_DisplayNameIsStored()
    {
        // Arrange
        var displayName = "Display Name";
        var request = DataBuilder.CreateSynthesizerRequest()
            .With(x => x.DisplayName, displayName).Create();

        // Act
        _sut.CreateSynthesizer(request);

        // Assert
        _mockedStore.Verify(x => x.SetSynthesizer(
            It.IsAny<SynthesizerId>(),
            It.Is<SynthesizerInformation>(y => y.DisplayName == displayName)));
    }

    #endregion
}