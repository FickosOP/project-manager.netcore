using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Exceptions
{
    public class IdExistingException<T> : Exception where T : IEntity
    {
        public override string Message
        {
            get
            {
                return $"Id already exists for entity of type {nameof(T)}";
            }
        }
    }
}
