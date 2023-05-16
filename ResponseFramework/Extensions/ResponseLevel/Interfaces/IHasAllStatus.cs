namespace ResponseFramework.Extensions.ResponseLevel.Interfaces;

public interface IHasAllStatus : IHasNoneStatus, IHasSuccessStatus, IHasInfoStatus, IHasInvalidResponse, 
    IHasErrorStatus, IHasCriticalStatus
{
}