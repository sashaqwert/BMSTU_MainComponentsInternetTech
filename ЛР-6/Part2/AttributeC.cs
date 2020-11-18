using System;
using System.Collections.Generic;
using System.Text;

namespace Part2
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
    class AttributeC : Attribute
    {
        public string Description
        {
            get;
            set;
        }

        public AttributeC() {}
        public AttributeC(string descriptionParam)
        {
            Description = descriptionParam;
        }
    }
}
