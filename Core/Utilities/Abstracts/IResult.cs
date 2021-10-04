using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Abstracts
{
    public interface IResult
    {
        string Message { get; set; }
        bool Success { get; set; }
    }
}
