using ResponseFramework.Extensions.ResponseLevel.Interfaces;

namespace ResponseFramework.Extensions.ResponseLevel;

public static class HasNoneStatus
{
    public static bool IsNone(this IHasNoneStatus response)
    {
        return response.GetCodeLevel() >= 0 && response.GetCodeLevel() <= 199;
    }
}