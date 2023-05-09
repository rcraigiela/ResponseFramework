using ResponseFramework.Configuration;
using ResponseFramework.Configuration.ResponseLevel;
using ResponseFramework.Factories;

namespace ResponseFramework.Tests.Helpers;

public class CreateResponseFactory : ResponseFactoryBase<CreateResponse, CreateResponseCode>
{
    public CreateResponse Success(string message)
    {
        return GenerateResponse(CreateResponseCode.Success, message);
    }
    
    public CreateResponse SuccessWithErrors(string message)
    {
        return GenerateResponse(CreateResponseCode.SuccessWithErrors, message);
    }
    
    public CreateResponse UnknownError(string message)
    {
        return GenerateResponse(CreateResponseCode.UnknownError, message);
    }
    
    /// <summary>
    /// Extension method called every time a success response is generated
    /// </summary>
    /// <param name="response"></param>
    [ResponseExtension(typeof(ResponseSuccess))]
    public void TestingSuccessExtensionMethod(CreateResponse response)
    {
        Console.WriteLine($"We logged a success response with message \"{response.Message}\"");
    }

    /// <summary>
    /// Extension method called every time an error response is generated
    /// </summary>
    /// <param name="response"></param>
    [ResponseExtension(typeof(ResponseError))]
    public void TestingErrorExtensionMethod(CreateResponse response)
    {
        Console.WriteLine($"We logged an error response with message \"{response.Message}\"");
    }
}