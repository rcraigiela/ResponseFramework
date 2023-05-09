namespace ResponseFramework.Configuration.ResponseLevel;

public class ResponseCritical : IResponseLevel
{
    public new static UInt16 LowerBound = 600;
    public new static UInt16 UpperBound = 1000;
}