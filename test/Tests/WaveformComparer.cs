using System.Collections;

namespace Tests;

public class WaveformComparer : IComparer
{
    private readonly double _accuracy;

    public WaveformComparer(double accuracy)
        => _accuracy = accuracy;

    public int Compare(object? x, object? y)
    {
        if (x == null || y == null) throw new ArgumentException("Comparer was called with null arguments.");

        var delta = (double)x - (double)y;
        if (delta < -_accuracy) return -1;
        if (delta > _accuracy) return 1;
        return 0;
    }
}