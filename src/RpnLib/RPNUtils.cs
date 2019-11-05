using System;
using System.Collections.Generic;

namespace com.sgcombo.RpnLib
{
    internal class RPNUtils
    {

        private static char[] operators = { '+', '-', '*', '/', '<', '>', '=', '%','^','(',')' };
        private static string[] doubleOperators = { "<>", ">=", "<=", "%=", "/=" };
        public static bool IsWhiteSpace(char chr)
        {
            return char.IsWhiteSpace(chr) || chr == '\r' || chr == '\n' || chr == '\t';
        }

        public static bool isOperation(char c)
        {
            for (int i = 0; i < operators.Length; i++)
                if (c == operators[i])
                    return true;

            return false;
        }
        public static bool GetTokens(string expr , List<RPNToken> Tokens)
        {


            int i = 0;
            string tok = string.Empty;
            RPNToken token;

            bool IsGood = true;
            Tokens.Clear();

            while (i <= expr.Length)
            {
                tok = string.Empty;
                token = new RPNToken();

                if (i > expr.Length - 1) { break; }

                if (RPNUtils.IsWhiteSpace(expr[i]))
                {
                    while (RPNUtils.IsWhiteSpace(expr[i]))
                    {
                        i++;
                        if (i > expr.Length - 1) { break; }
                    }
                }

                if (i > expr.Length - 1) { break; }

                if (expr[i] == '\'')
                {
                    while (!(expr[i] == '\''))
                    {
                        tok += expr[i];
                        i++;
                        if (i > expr.Length - 1) {
                            throw new Exception($"Invalid string [{tok}]");
                        }
                    }
                    if (i <= expr.Length - 1)
                    {
                        {
                            tok += expr[i];
                            i++;
                        }
                    }
                    token.sType = RPNTokenType.STRING;
                    token.sToken = tok;
                    Tokens.Add(token);
                }

                if (i > expr.Length - 1) { break; }

                if (expr[i] == '[')
                {
                    while (!(expr[i] == ']'))
                    {
                        tok += expr[i];
                        i++;
                        if (i > expr.Length - 1) { break; }
                    }
                    if (i <= expr.Length - 1)
                    {
                        {
                            tok += expr[i];
                            i++;
                        }
                    }
                    token.sType = RPNTokenType.STRING;
                    token.sToken = tok;
                    Tokens.Add(token);
                }

                if (i > expr.Length - 1) { break; }

                if (expr[i] == '"')
                {
                    while (!(expr[i] == '"'))
                    {
                        tok += expr[i];
                        i++;
                        if (i > expr.Length - 1) {
                            throw new Exception($"Invalid string [{tok}]");
                        }
                    }
                    if (i <= expr.Length - 1)
                    {
                        {
                            tok += expr[i];
                            i++;
                        }
                    }
                    token.sType = RPNTokenType.STRING;
                    token.sToken = tok;
                    Tokens.Add(token);
                }

                if (i > expr.Length - 1) { break; }

                if (char.IsLetter(expr[i]))
                {
                    while (char.IsLetter(expr[i]) || (char.IsDigit(expr[i]) || (expr[i] == '_')))
                    {
                        tok += expr[i];
                        i++;
                        if (i > expr.Length - 1) { break; }
                    }
                    token.sType = RPNTokenType.ALPHA;
                    if (i < expr.Length )
                    {
                        if (expr[i] == '(')
                        {
                            tok += "$";
                            token.OperandType = RPNOperandType.Function;
                            token.sType = RPNTokenType.OPERAND;
                        }
                        if (expr[i] == '$')
                        {
                            tok += "$";
                            i++;
                            token.OperandType = RPNOperandType.Function;
                            token.sType = RPNTokenType.OPERAND;
                        }
                    }
                    token.sToken = tok;
                    Tokens.Add(token);
                }
                else if (char.IsDigit(expr[i]))
                {
                    while (char.IsDigit(expr[i]) || (expr[i] == '.'))
                    {
                        tok += expr[i];
                        i++;
                        if (i > expr.Length - 1) { break; }
                    }
                    token.sType = RPNTokenType.NUMBER;
                    token.sToken = tok;
                    Tokens.Add(token);
                }
                else if (isOperation(expr[i]))
                {
                    tok = expr[i].ToString();
                    token.sType = RPNTokenType.OPERAND;
                    token.sToken = tok;
                    Tokens.Add(token);
                    i++;
                    if (i > expr.Length - 1) { break; }
                }
                else
                {
                    IsGood = false;
                    Tokens.Clear();
                    if (i < expr.Length)
                    {
                        throw new Exception($"Invalid token type [{expr[i]}] Expression [{expr}]");
                    }
                    else
                    {
                        throw new Exception($"Invalid Expression [{expr}]");
                    }
                }

            }
            return IsGood;
        }

    }
}
