using ResponseFramework.Extensions.ResponseLevel.Interfaces;

namespace ResponseFramework.Extensions.ResponseLevel;

public static class HasErrorStatus
{
    public static bool IsError(this IHasErrorStatus response)
    {
        return response.GetCodeLevel() >= 500 && response.GetCodeLevel() <= 599;
    }
}