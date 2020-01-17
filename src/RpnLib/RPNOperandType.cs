
using System.Collections.Generic;


namespace com.sgcombo.RpnLib
{
    internal enum RPNOperandType
    {
        UNKNOWN,
        START_PARENTHESES,
        END_PARENTHESES,
      

        //operators
        MULITIPLY,
        DIVIDE,
        PLUS,
        MINUS,
        LESS,
        GREATER,
        LESSOREQUAL,
        GREATEOREQUAL,
        NOTEQUAL,
        EQUAL,
        OR,
        AND,
        NOT,
        JUSTPLUS,
        JUSTMINUS,
        ARIFMETICAL,
        DIV,
        EXPONENTIATION,
        MOD
    };

    internal class OperationConvertor
    {

        public static char[] operators = { '+', '-', '*', '/', '<', '>', '=', '%', '^', '(', ')', '~', 'x', '÷','≥','≤' };
        public static string[] doubleOperators = { "<>", ">=", "<=", "%=", "/=","==","||","&&" };

        public static Dictionary<string, RPNOperandType> GetOperation = new Dictionary<string, RPNOperandType>()
        {
{ "*",RPNOperandType.MULITIPLY},
{ "/",RPNOperandType.DIVIDE},
{ "÷",RPNOperandType.DIVIDE},
{ "/=",RPNOperandType.DIV},
{ "^",RPNOperandType.EXPONENTIATION },
{ "%=",RPNOperandType.MOD },
{ "+",RPNOperandType.PLUS},
{ "-",RPNOperandType.MINUS},
{ "~",RPNOperandType.JUSTMINUS},
{ "<",RPNOperandType.LESS},
{ ">",RPNOperandType.GREATER},
{ "<=",RPNOperandType.LESSOREQUAL},
{ "≤",RPNOperandType.LESSOREQUAL},
{ ">=",RPNOperandType.GREATEOREQUAL},
{ "≥",RPNOperandType.GREATEOREQUAL},
{ "!=",RPNOperandType.NOTEQUAL},
{ "==",RPNOperandType.EQUAL},
{ "=",RPNOperandType.EQUAL},
{ "||",RPNOperandType.OR},
{ "&&",RPNOperandType.AND},
{ "!",RPNOperandType.NOT},
{ "(",RPNOperandType.START_PARENTHESES },
{ ")",RPNOperandType.END_PARENTHESES }

        };

    };
}
