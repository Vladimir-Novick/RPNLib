
using System.Collections.Generic;


namespace com.sgcombo.RpnLib
{
    internal enum RPNOperandType
    {
        Unknown,
        StartParentheses,
        EndParentheses,
      

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

        public static char[] operators = { '+', '-', '*', '/', '<', '>', '=', '%', '^', '(', ')', '~', 'x' };
        public static string[] doubleOperators = { "<>", ">=", "<=", "%=", "/=","==","||","&&" };

        public static Dictionary<string, RPNOperandType> GetOperation = new Dictionary<string, RPNOperandType>()
        {
{ "*",RPNOperandType.Mulitiply},
{ "x",RPNOperandType.Mulitiply},
{ "/",RPNOperandType.Divide},
{ "/=",RPNOperandType.Div},
{ "^",RPNOperandType.Exponentiation },
{ "%=",RPNOperandType.Mod },
{ "+",RPNOperandType.Plus},
{ "-",RPNOperandType.Minus},
{ "~",RPNOperandType.JustMinus},
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
