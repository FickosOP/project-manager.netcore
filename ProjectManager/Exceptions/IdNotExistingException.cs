using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Exceptions
{
    public class IdNotExistingException<T> : Exception where T : IEntity
    {
        public override string Message
        {
            get
            {
                return $"Id you want to replace doesn't exist for entity of type {nameof(T)}";
            }
        }
    }
}
