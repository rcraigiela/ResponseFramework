using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ResponseFramework.Configuration;

namespace ResponseFramework.Responses;

public class ResponseBase<ResponseCode> : IResponse
{
    public ResponseCode Code { get; protected set; }

    public string Message { get; protected set; }

    public ResponseBase(ResponseCode responseCode, string message)
    {
        Code = responseCode;
        Message = message;
    }

    public int GetCodeLevel()
    {
        return Convert.ToInt32(Code);
    }
}