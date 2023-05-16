using ResponseFramework.Extensions.ResponseLevel.Interfaces;

namespace ResponseFramework.Extensions.ResponseLevel;

public static class HasInvalidStatus
{
    public static bool IsInvalid(this IHasInvalidResponse response)
    {
        return response.GetCodeLevel() >= 400 && response.GetCodeLevel() <= 499;
    }
}