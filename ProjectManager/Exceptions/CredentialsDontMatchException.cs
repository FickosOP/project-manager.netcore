using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Exceptions
{
    public class CredentialsDontMatchException : Exception
    {
        public override string Message
        {
            get
            {
                return "No matching credentials.";
            }
        }
    }
}
