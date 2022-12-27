using Tests.DataBuilders;

namespace Tests;

public partial class BaseUnitTest
{
    internal readonly DataBuilder DataBuilder = new();

    protected static double DefaultDoubleTolerance(double value = 0)
    {
        return double.Max(value * 1e-9, double.Epsilon);
    }
}