namespace Application.NAudio.Wrapping;

public abstract class WrappedBase<T> where T : class
{
    protected readonly T SourceObject;

    protected WrappedBase(T sourceObject)
    {
        SourceObject = sourceObject;
    }
}