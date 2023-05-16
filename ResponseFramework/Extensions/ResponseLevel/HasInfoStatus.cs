using ResponseFramework.Extensions.ResponseLevel.Interfaces;

namespace ResponseFramework.Extensions.ResponseLevel;

public static class HasInfoStatus
{
    public static bool IsInfo(this IHasInfoStatus response)
    {
        return response.GetCodeLevel() >= 300 && response.GetCodeLevel() <= 399;
    }
}