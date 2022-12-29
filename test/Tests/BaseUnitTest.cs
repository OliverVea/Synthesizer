namespace Tests;

public partial class BaseUnitTest
{
    protected readonly DataBuilder DataBuilder = new();

    protected static double DefaultDoubleTolerance(double value = 0)
    {
        return double.Max(value * 1e-9, double.Epsilon);
    }
}