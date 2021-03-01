using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sgcombo.RpnLib
{
    public struct RPNArguments
    {
        public string name;
        public double value;
        public RPNArguments(string _name, double _value)
        {
            name = _name;
            value = _value;
        }

    }
}
