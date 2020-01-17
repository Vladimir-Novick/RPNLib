
using System.Collections.Generic;


namespace com.sgcombo.RpnLib
{
    internal enum RPNOperandType
    {
        UNKNOWN,
        STAR_TPARENTHESES,
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
        OR_OPERATOR,
        AND_OPERATOR,
        NOT_OPERATOR,
        JUSTPLUS,
        JUSTMINUS,
        ARIFMETICAL,
        DIV_OPERATOR,
        EXPONENTIATION,
        MOD_OPERATOR
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
{ "/=",RPNOperandType.DIV_OPERATOR},
{ "^",RPNOperandType.EXPONENTIATION },
{ "%=",RPNOperandType.MOD_OPERATOR },
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
{ "||",RPNOperandType.OR_OPERATOR},
{ "&&",RPNOperandType.AND_OPERATOR},
{ "!",RPNOperandType.NOT_OPERATOR},
{ "(",RPNOperandType.STAR_TPARENTHESES },
{ ")",RPNOperandType.END_PARENTHESES }

        };

    };
}
