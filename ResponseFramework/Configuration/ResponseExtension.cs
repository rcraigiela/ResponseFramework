using ResponseFramework.Configuration.ResponseLevel;

namespace ResponseFramework.Configuration;

[System.AttributeUsage(System.AttributeTargets.Method)]
public class ResponseExtension : Attribute
{
    public Type ResponseLevel { get; protected set; }

    public ResponseExtension(Type responseLevel)
    {
        var interfaces = responseLevel.GetInterfaces();
        if (!typeof(IResponseLevel).IsAssignableFrom(responseLevel))
        {
            throw new InvalidCastException($"Response Extension attributes must be passed a type of IResponseLevel, type is {responseLevel}");
        }

        ResponseLevel = responseLevel;
    }
}