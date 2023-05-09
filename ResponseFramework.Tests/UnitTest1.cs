using ResponseFramework.Configuration.ResponseLevel;
using ResponseFramework.Tests.Helpers;

namespace ResponseFramework.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestSuccessResponse()
    {
        var response = CreateResponse.Factory.Success("It succeeded!");

        Assert.That(response.Code, Is.EqualTo(CreateResponseCode.Success));
        Assert.True(response.Is<ResponseSuccess>());
        Assert.False(response.Is<ResponseCritical>());
        Assert.False(response.Is<ResponseError>());
        Assert.False(response.Is<ResponseInfo>());
        Assert.False(response.Is<ResponseInvalid>());
        Assert.False(response.Is<ResponseNone>());

        if (response.Code == CreateResponseCode.Success)
        {
            Console.WriteLine("Doing some work because we were successful");
        }
    }

    [Test]
    public void TestErrorResponse()
    {
        var response = CreateResponse.Factory.UnknownError("An unknown error has occurred");
        
        Assert.That(response.Code, Is.EqualTo(CreateResponseCode.UnknownError));
        Assert.False(response.Is<ResponseSuccess>());
        Assert.False(response.Is<ResponseCritical>());
        Assert.True(response.Is<ResponseError>());
        Assert.False(response.Is<ResponseInfo>());
        Assert.False(response.Is<ResponseInvalid>());
        Assert.False(response.Is<ResponseNone>());

        if (response.Code == CreateResponseCode.UnknownError)
        {
            Console.WriteLine("Doing some work because we encountered an unknown error");
        }
    }
}