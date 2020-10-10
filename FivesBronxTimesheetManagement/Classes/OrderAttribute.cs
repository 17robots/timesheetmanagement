using System;
using System.Runtime.CompilerServices;

namespace FivesBronxTimesheetManagement.Classes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    class OrderAttribute : Attribute
    {
        public OrderAttribute([CallerLineNumber] int order = 0)
        {
            Order = order;
        }

        public int Order { get; }
    }
}
