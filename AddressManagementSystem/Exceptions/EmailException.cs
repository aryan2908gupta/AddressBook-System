using System;
using System.Collections.Generic;
using System.Text;

namespace AddressManagementSystem.Exceptions
{
public class EmailException : Exception
    {
        public EmailException(string msg) : base(msg) { }
    }
}
