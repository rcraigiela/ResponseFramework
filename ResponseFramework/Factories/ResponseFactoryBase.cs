using System.Reflection;
using ResponseFramework.Configuration;
using ResponseFramework.Configuration.ResponseLevel;
using ResponseFramework.Responses;

namespace ResponseFramework.Factories;

public abstract class ResponseFactoryBase<ResponseType, ResponseCode>
    where ResponseType : ResponseBase<ResponseCode>
    where ResponseCode : struct, Enum, IComparable
{
    protected ResponseType GenerateResponse(ResponseCode code, string message)
    {
        var objectResponse = Activator.CreateInstance(typeof(ResponseType), new object[] { code, message });
        if (objectResponse == null)
        {
            throw new NullReferenceException($"Unable to create instance of response type {typeof(ResponseType)}");
        }

        ResponseType response = (ResponseType)objectResponse;
        CallExtensions(response);
        
        return response;
    }

    protected void CallExtensions(ResponseType response)
    {
        // Find extensions of the appropriate type
        var methods = GetType().GetMethods()
            .Where(method => method.GetCustomAttributes(typeof(ResponseExtension), false).Length > 0).ToList();

        // Call them
        foreach (var method in methods)
        {
            // Options
            // Manually get the type, cast it, and determine the type in here
            // 
            var attribute = method.GetCustomAttributes<ResponseExtension>().First();
            if (IsMethodExtendingResponse(response, attribute.ResponseLevel))
            {
                method.Invoke(this, new object[] { response });
            }
        }
    }

    protected bool IsMethodExtendingResponse(ResponseType response, Type responseLevel)
    {
        // Utilizing reflection, gets the bounds of the object
        FieldInfo lowerField = responseLevel.GetField("LowerBound");
        FieldInfo upperField = responseLevel.GetField("UpperBound");
        if (lowerField == null || upperField == null)
        {
            return false;
        }

        UInt16? lowerBound = lowerField.GetValue(null) as UInt16?;
        UInt16? upperBound = upperField.GetValue(null) as UInt16?;

        int level = response.GetCodeLevel();
        
        return lowerBound <= level && level <= upperBound;
    }
}