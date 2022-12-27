namespace Synthesizer.Abstractions.Models;

public struct AudioSample
{
    public SynthesizerId Source;
    public long Timestamp;
    public int[] Samples;
}