using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class DerivedFromAttribute : Attribute
{
    public Type From { get; set; }

    public DerivedFromAttribute(Type from)
    {
        From = from;
    }
}
