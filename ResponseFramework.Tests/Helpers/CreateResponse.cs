using ResponseFramework.Extensions;
using ResponseFramework.Extensions.ResponseLevel.Interfaces;
using ResponseFramework.Responses;

namespace ResponseFramework.Tests.Helpers;

public enum CreateResponseCode
{
    None = 0,
    Success = 200,
    SuccessWithErrors = 300,
    InvalidRequest = 400,
    UnknownError = 500,
}

public class CreateResponse : ResponseBase<CreateResponseCode>, IHasAllStatus
{
    public static CreateResponseFactory Factory = new CreateResponseFactory();
    
    public CreateResponse(CreateResponseCode responseCode, string message) : base(responseCode, message)
    {
    }

    public void Test()
    {
    }
}