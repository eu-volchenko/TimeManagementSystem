using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManagementSystem.BLL.Infrastructure
{
    class ValidationException : Exception
    {
        public string MyProperty { get; set; }
        public ValidationException(string message, string prop) : base(message)
        {
            MyProperty = prop;
        }
    }
}