using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ResponseFramework.Configuration;
using ResponseFramework.Configuration.ResponseLevel;

namespace ResponseFramework.Responses;

public class ResponseBase<ResponseCode>
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

    public bool Is<Level>() where Level : IResponseLevel
    {
        // Utilizing reflection, gets the bounds of the object
        FieldInfo lowerField = typeof(Level).GetField("LowerBound");
        FieldInfo upperField = typeof(Level).GetField("UpperBound");
        if (lowerField == null || upperField == null)
        {
            return false;
        }

        UInt16? lowerBound = lowerField.GetValue(null) as UInt16?;
        UInt16? upperBound = upperField.GetValue(null) as UInt16?;

        int level = GetCodeLevel();
        
        return lowerBound <= level && level <= upperBound;
    }

    public static bool operator ==(ResponseBase<ResponseCode> response, ResponseCode code) => response.Code == code;
}
