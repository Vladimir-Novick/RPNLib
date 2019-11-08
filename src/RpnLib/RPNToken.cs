using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sgcombo.RpnLib
{
    internal struct RPNToken
    {
        public RPNTokenType sType;
        public string sToken;
        public RPNOperandType OperandType;
        internal RPNOperandType Operation;
    }
}
