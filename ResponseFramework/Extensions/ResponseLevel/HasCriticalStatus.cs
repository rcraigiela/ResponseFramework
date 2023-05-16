using ResponseFramework.Extensions.ResponseLevel.Interfaces;

namespace ResponseFramework.Extensions.ResponseLevel;

public static class HasCriticalStatus
{
    public static bool IsCritical(this IHasCriticalStatus response)
    {
        return response.GetCodeLevel() >= 600 && response.GetCodeLevel() <= 699;
    }
}