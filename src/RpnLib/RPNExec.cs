using System;
using System.Collections.Generic;


namespace com.sgcombo.RpnLib
{

    internal class RPNExec
    {

        private List<RPNToken> Tokens = new List<RPNToken>();
        private Stack<object> al;
        private Dictionary<string, RPNArguments> vars = new Dictionary<string, RPNArguments>();
        private RPNEnvironment Environment = new RPNEnvironment();
        public RPNExec(List<RPNToken> _Tokens)
        {
            Tokens = _Tokens;
            RPNFunctions.RegisterFunctions(Environment);
        }


        public object Exec()
        {

            object ret = "";
            int i = 0;
            double a = 0;
            double b = 0;
            bool a1 = true;
            bool b1 = true;
            string tok = string.Empty;
            //Go though the tokens
            al = new Stack<object>();
            int x = 0;
            while (i < Tokens.Count)
            {
                tok = Tokens[i].sToken;

                switch (Tokens[i].sType)
                {
                    case RPNTokenType.NONE:
                        break;
                    case RPNTokenType.ALPHA:
                        if (tok.Equals("true"))
                        {
                            al.Push(true);
                            break;
                        }
                        if (tok.Equals("false"))
                        {
                            al.Push(false);
                            break;
                        }
                        if (vars.TryGetValue(tok, out RPNArguments arg))
                        {
                            a = arg.value;
                            al.Push(a);
                        }
                        else
                        {
                            throw new Exception($"Value [{tok}] not exists");
                        }
                        break;
                    case RPNTokenType.NUMBER:
                        al.Push(double.Parse(tok));
                        break;
                    case RPNTokenType.STRING:
                        al.Push(tok.Substring(1, tok.Length - 2));
                        break;
                    case RPNTokenType.FUNCTION:

                        if (this.Environment != null)
                        {

#if DEBUG
                            String argumentList = "";
#endif

                            String funcName = Tokens[i].sToken;
                            funcName = funcName.Substring(0, funcName.Length - 1);


                            var func = this.Environment.FindFunction(funcName);
                            if (func != null)
                            {
                                FunctionAttribute funcAttrib = (FunctionAttribute)Attribute.GetCustomAttribute(func.GetType(), typeof(FunctionAttribute));
                                List<object> arguments = new List<object>();



                                if (funcAttrib.ParamTypes != null && funcAttrib.ParamTypes.Length > 0)
                                {
                                    foreach (var paramType in funcAttrib.ParamTypes)
                                    {
                                        object obj = al.Pop();
                                        func.Params.Add(obj);
#if DEBUG
                                        argumentList += " ";
                                        argumentList += obj.ToString();
#endif
                                    }

                                }

                                object retObject = func.Calc();

                                al.Push(retObject);
#if DEBUG
                                Console.WriteLine($"Function , {funcName}({argumentList})  = {retObject.ToString()}");


#endif

                                //   al.Push(r);
                            }

                        }
                        break;
                    case RPNTokenType.OPERAND:
                        object r = 0;

                        switch (Tokens[i].Operation)
                        {
                            case RPNOperandType.JUSTPLUS:
                                a = Convert.ToDouble(al.Pop());
                                r = +a;
#if DEBUG
                                Console.WriteLine($"JustPlus , {r}  = {a.ToString()}");


#endif

                                break;
                            case RPNOperandType.PLUS:
                                a = Convert.ToDouble(al.Pop());
                                var b11 = al.Pop();
                                if ("DateTime" == b11.GetType().Name)
                                {
                                    DateTime dDateTime = (DateTime)b11;
                                    r = dDateTime.AddHours(a);
                                }
                                else
                                {
                                    b = Convert.ToDouble(b11);
                                    r = a + b;
                                }

#if DEBUG
                                Console.WriteLine($"{b.ToString()} + {a.ToString()} = {r.ToString()}");
#endif
                                break;
                            case RPNOperandType.JUSTMINUS:
                                a = Convert.ToDouble(al.Pop());
                                r = -a;
                                break;
                            case RPNOperandType.MINUS:
                                a = Convert.ToDouble(al.Pop());
                                var b12 = al.Pop();
                                if ("DateTime" == b12.GetType().Name)
                                {
                                    DateTime dDateTime = (DateTime)b12;
                                    r = dDateTime.AddHours(-a);
                                }
                                else
                                {
                                    b = Convert.ToDouble(b12);
                                    r =  b - a;
                                }
#if DEBUG
                                Console.WriteLine($"{b} - {a} = {r}");
#endif

                                break;
                            case RPNOperandType.MULITIPLY:
                                a = Convert.ToDouble(al.Pop());
                                b = Convert.ToDouble(al.Pop());
                                r = a * b;
#if DEBUG
                                Console.WriteLine($"{b} * {a} = {r}");
#endif

                                break;
                            case RPNOperandType.DIVIDE:
                                a = Convert.ToDouble(al.Pop());
                                b = Convert.ToDouble(al.Pop());
                                r = (b / a);

#if DEBUG
                                Console.WriteLine($"{b} / {a} = {r}");
#endif
                                break;
                            case RPNOperandType.EXPONENTIATION:
                                a = Convert.ToDouble(al.Pop());
                                b = Convert.ToDouble(al.Pop());
                                r = Math.Pow(b, a);
#if DEBUG
                                Console.WriteLine($"{b} ^ {a} = {r}");
#endif
                                break;

                            case RPNOperandType.DIV_OPERATOR:  // "/="
                                a = Convert.ToDouble(al.Pop());
                                b = Convert.ToDouble(al.Pop());
                                r = (b / a);
#if DEBUG
                                Console.WriteLine($"{b} /= {a} = {r}");
#endif
                                break;
                            case RPNOperandType.MOD_OPERATOR:  //"%=",
                                a = Convert.ToDouble(al.Pop());
                                b = Convert.ToDouble(al.Pop());
                                r = (b %= a);
#if DEBUG
                                Console.WriteLine($"{b} %= {a} = {r}");
#endif
                                break;
                            case RPNOperandType.LESS:  //"<",
                                a = Convert.ToDouble(al.Pop());
                                b = Convert.ToDouble(al.Pop());
                                r = (b < a);
#if DEBUG
                                Console.WriteLine($"{b} < {a} = {r}");
#endif
                                break;
                            case RPNOperandType.GREATER:  //">",
                                a = Convert.ToDouble(al.Pop());
                                b = Convert.ToDouble(al.Pop());
                                r = (b > a);
#if DEBUG
                                Console.WriteLine($"{b} > {a} = {r}");
#endif
                                break;
                            case RPNOperandType.LESSOREQUAL:  //"<=",
                                a = Convert.ToDouble(al.Pop());
                                b = Convert.ToDouble(al.Pop());
                                r = (b <= a);
#if DEBUG
                                Console.WriteLine($"{b} <= {a} = {r}");
#endif
                                break;
                            case RPNOperandType.GREATEOREQUAL:  //">=",
                                a = Convert.ToDouble(al.Pop());
                                b = Convert.ToDouble(al.Pop());
                                r = (b >= a);
#if DEBUG
                                Console.WriteLine($"{b} >={a} = {r}");
#endif
                                break;

                            case RPNOperandType.NOTEQUAL:  //"!=",
                                a = Convert.ToDouble(al.Pop());
                                b = Convert.ToDouble(al.Pop());
                                r = (b != a);
#if DEBUG
                                Console.WriteLine($"{b} !={a} = {r}");
#endif
                                break;
                            case RPNOperandType.EQUAL:  //"=="
                                a = Convert.ToDouble(al.Pop());
                                b = Convert.ToDouble(al.Pop());
                                r = (b == a);
#if DEBUG
                                Console.WriteLine($"{b} =={a} = {r}");
#endif
                                break;

                            case RPNOperandType.OR_OPERATOR:  //"||",
                                a1 = Convert.ToBoolean(al.Pop());
                                b1 = Convert.ToBoolean(al.Pop());
                                r = (b1 || a1);
#if DEBUG
                                Console.WriteLine($"{b1} || {a1} = {r}");
#endif
                                break;


                            case RPNOperandType.AND_OPERATOR:  //"&&",

                                a1 = Convert.ToBoolean(al.Pop());
                                b1 = Convert.ToBoolean(al.Pop());
                                r = (b1 && a1);
#if DEBUG
                                Console.WriteLine($"{b1} && {a1} = {r}");
#endif
                                break;

                            case RPNOperandType.NOT_OPERATOR:  //"!",
                                a1 = Convert.ToBoolean(al.Pop());
                                r = (!a1);
#if DEBUG
                                Console.WriteLine($" !{a1} = {r}");
#endif
                                break;

                        }
                        al.Push(r);
                        break;
                }
                i++;
            }

            while (x < al.Count) { ret = al.Pop(); }

            return ret;
        }

        public void AddVar(string key, double num)
        {
            vars[key] = (new RPNArguments(key, num));
        }

        internal void AddVar(List<RPNArguments> argument)
        {
            foreach (var item in argument)
            {
                vars[item.name] = item;
            }
        }

        public object Result
        {
            get
            {
                return Exec();
            }
        }


    }
}
