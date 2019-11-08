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
        JustMinus,
        Arifmetical,
        Div,
        Exponentiation,
        Mod
    }

    internal class OperationConvertor
    {

        public static char[] operators = { '+', '-', '*', '/', '<', '>', '=', '%', '^', '(', ')' };
        public static string[] doubleOperators = { "<>", ">=", "<=", "%=", "/=","==","||","&&" };

        public static Dictionary<string, RPNOperandType> GetOperation = new Dictionary<string, RPNOperandType>()
        {
{ "*",RPNOperandType.Mulitiply},
{ "/",RPNOperandType.Divide},
{ "/=",RPNOperandType.Div},
{ "^",RPNOperandType.Exponentiation },
 { "%=",RPNOperandType.Mod },
{ "+",RPNOperandType.Plus},
{ "-",RPNOperandType.Minus},
{ "<",RPNOperandType.Less},
{ ">",RPNOperandType.Greater},
{ "<=",RPNOperandType.LessOrEqual},
{ ">=",RPNOperandType.GreateOrEqual},
{ "!=",RPNOperandType.NotEqual},
{ "==",RPNOperandType.Equal},
{ "||",RPNOperandType.Or},
{ "&&",RPNOperandType.And},
{ "!",RPNOperandType.Not},
{ "(",RPNOperandType.StartParentheses },
{ ")",RPNOperandType.EndParentheses }

        };

    }
}
