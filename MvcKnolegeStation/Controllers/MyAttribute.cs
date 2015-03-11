using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolFunction;

namespace MvcKnolegeStation.Controllers
{
    [AttributeUsage(AttributeTargets.Method)] 
    public class MyAttribute:Attribute
    {
        public MyAttribute(string p_strName) {
            name = p_strName;
        }
        public string name;
    }
}