using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FivesBronxTimesheetManagement.Classes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    class OrderAttribute : System.Attribute
    {
        private readonly int order;
        public OrderAttribute([CallerLineNumber] int order = 0)
        {
            this.order = order;
        }

        public int Order { get { return order; } }
    }
}
