using ResponseFramework.Extensions.ResponseLevel.Interfaces;

namespace ResponseFramework.Extensions.ResponseLevel;

public static class HasSuccessStatus
{
    public static bool IsSuccess(this IHasSuccessStatus response)
    {
        return response.GetCodeLevel() >= 200 && response.GetCodeLevel() <= 299;
    }
}