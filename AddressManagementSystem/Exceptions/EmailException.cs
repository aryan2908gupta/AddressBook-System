using System;
using System.Collections.Generic;
using System.Text;

namespace AddressManagementSystem.Exceptions
{
    internal class EmailException : Exception
    {
        public EmailException(string msg) : base(msg) { }
    }
}
