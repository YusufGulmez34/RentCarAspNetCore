using Core.Utilities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Concrete
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(string message):base(default, message, false)
        {

        }

        public ErrorDataResult():base(default,false)
        {

        }
    }
}
