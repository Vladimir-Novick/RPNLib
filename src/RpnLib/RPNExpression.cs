﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace com.sgcombo.RpnLib
{
    public class RPNExpression
    {


        private   List<RPNToken> Tokens = new List<RPNToken>();
        private   string m_expr = string.Empty;

        public RPNExpression(string expr)
        {
            m_expr = expr;
        }

        public string GetSourceString()
        {
            return m_expr;
        }

        int precedence(char c)
        {
            int order = 0;
            //Order of operators
            switch (c)
            {
                case '(':
                case ')':
                    order = 1;
                    break;
                case '+':
                case '-':
                    order = 2;
                    break;
                case '*':
                case '/':
                    order = 3;
                    break;
                case '^':
                    order = 4;
                    break;
                default:
                    order = 0;
                    break;
            }
            return order;
        }

        public object Calculate(List<RPNArguments> argument = null)
        {
            RPNExec exec = new RPNExec(execTokens);
            if (argument != null)
            {
                exec.AddVar(argument);
            }
            return exec.Exec();
        }

        private List<RPNToken> execTokens = new List<RPNToken>();

        public   string Prepare()
        {
            int x = 0;
            Stack<RPNToken> stack = new Stack<RPNToken>();
            Stack<RPNToken> postfix = new Stack<RPNToken>();
            string RetVal = string.Empty;
           
            RPNToken sItem;
            RPNToken tok;
            RPNTokenType types;

            RPNUtils.GetTokens(m_expr, Tokens);

            while (x < Tokens.Count)
            {
                tok = Tokens[x];
                types = tok.sType;

                //Check for numbers
                if (types == RPNTokenType.NONE || types == RPNTokenType.NUMBER || types == RPNTokenType.ALPHA || types == RPNTokenType.STRING)
                {
                    //Push number onto postfix stack.
                    postfix.Push(tok);
                }
                else
                {
                    //Check for LPARM
                    if (tok.sToken[0] == '(')
                    {
                        //Push ( onto stack.
                        stack.Push(tok);
                    }
                    //Check for closing param
                    else if (tok.sToken[0] == ')')
                    {
                        sItem = stack.Pop();
                        while (sItem.sToken[0] != '(')
                        {
                            //Post item of stack onto postfix stack.
                            postfix.Push(sItem);
                            sItem = stack.Pop();
                        }
                    }
                    else
                    {
                        //While the stack is not empty pop of rest of items.
                        while (stack.Count > 0)
                        {
                            //Get top item
                            sItem = stack.Pop();
                            //Check order of operators.
                            if (precedence(sItem.sToken[0]) >= precedence(tok.sToken[0]))
                            {
                                //Push operator on stack
                                postfix.Push(sItem);

                            }
                            else
                            {
                                //Push back onto stack.
                                stack.Push(sItem);
                                break;
                            }
                        }
                        //Push current token.
                        stack.Push(tok);
                    }
                }
                //INC Counter
                x++;
            }

            //Pop off remaining on the stack.
            while (stack.Count > 0)
            {
                //Add to postfix.
                postfix.Push(stack.Pop());
            }

            //Convert stack to string array.
            execTokens = postfix.Reverse().ToList();

            for (x = 0; x < execTokens.Count; x++)
            {
                //Append string to RetVal
                RetVal += execTokens[x].sToken + " ";
            }
            //Return RPN string
            return RetVal.Trim();
        }
    }
}