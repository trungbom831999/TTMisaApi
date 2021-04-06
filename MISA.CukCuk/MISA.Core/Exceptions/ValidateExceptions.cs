using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Exceptions
{
    public class ValidateExceptions:Exception
    {
        public ValidateExceptions(string msg) : base(msg)
        {

        }

        public ValidateExceptions(string msg, string[] arrayMsg) : base(msg, new Exception())
        {

        }
    }
}
