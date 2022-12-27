namespace Synthesizer.Abstractions.Models;

public record SynthesizerId
{
    private string _id;

    private SynthesizerId(Guid guid)
        => _id = guid.ToString();

    public static SynthesizerId NewId()
        => new(Guid.NewGuid());
}