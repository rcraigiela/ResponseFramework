using ResponseFramework.Configuration.ResponseLevel;
using ResponseFramework.Extensions;
using ResponseFramework.Extensions.ResponseLevel;
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
        Assert.True(response.IsSuccess());
        Assert.False(response.IsNone());
        Assert.False(response.IsInfo());
        Assert.False(response.IsInvalid());
        Assert.False(response.IsError());
        Assert.False(response.IsCritical());

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
        Assert.False(response.IsSuccess());
        Assert.False(response.IsNone());
        Assert.False(response.IsInfo());
        Assert.False(response.IsInvalid());
        Assert.True(response.IsError());
        Assert.False(response.IsCritical());

        if (response.Code == CreateResponseCode.UnknownError)
        {
            Console.WriteLine("Doing some work because we encountered an unknown error");
        }
    }
}