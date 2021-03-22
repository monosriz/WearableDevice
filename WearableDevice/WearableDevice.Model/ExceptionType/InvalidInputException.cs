using System;
using System.Collections.Generic;
using System.Text;

namespace WearableDevice.Model.ExceptionType
{
    public class InvalidInputException : System.Exception
    {


        public override string Message
        {
            get
            {
                return "input is invalid.";
            }
        }
    }
}
