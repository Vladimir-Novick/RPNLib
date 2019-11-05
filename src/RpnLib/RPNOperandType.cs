using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.sgcombo.RpnLib
{
    internal enum RPNOperandType
    {
        Unknown,
        StartParentheses,
        EndParentheses,
        Function,

        //operators
        Mulitiply,
        Divide,
        Plus,
        Minus,
        Less,
        Greater,
        LessOrEqual,
        GreateOrEqual,
        NotEqual,
        Equal,
        Or,
        And,
        Not,
        JustPlus,
        JustMinus
    }
}
