namespace ResponseFramework.Configuration.ResponseLevel;

public class ResponseError : IResponseLevel
{
    public new static UInt16 LowerBound = 500;
    public new static UInt16 UpperBound = 599;
}