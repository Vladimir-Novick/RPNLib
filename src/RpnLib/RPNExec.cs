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
                        if (vars.TryGetValue(tok, out RPNArguments arg)){
                            a = arg.value;
                            al.Push(a);
                        } else
                        {
                            throw new Exception($"Value [{tok}] not exists");
                        }
                        break;
                    case RPNTokenType.NUMBER:
                        al.Push(double.Parse(tok));
                        break;
                    case RPNTokenType.STRING:
                        al.Push(tok.Substring(1,tok.Length-2));
                        break;
                    case RPNTokenType.OPERAND:
                        object r = 0;
                        if (Tokens[i].OperandType == RPNOperandType.Function)
                        {

                            if (this.Environment != null)
                            {
                                double r1 = 0;
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
                                            a = Convert.ToDouble(obj);
                                            func.Params.Add(a);
#if DEBUG
                                            argumentList += " ";
                                            argumentList += a.ToString();
#endif
                                        }

                                    }

                                    object retObject = func.Calc();
                                    r1 = Convert.ToDouble(retObject);
                                    al.Push(r1);

                                    //   al.Push(r);
                                }
#if DEBUG
                                Console.WriteLine($"Function , {funcName}  = {r1}");
#endif
                            }
                        }
                        else
                        {
                         
                            switch (tok[0])
                            {
                                case '+':
                                    a = Convert.ToDouble(al.Pop());
                                    b = Convert.ToDouble(al.Pop());
                                    r = a + b;
#if DEBUG
                                    Console.WriteLine($"{b} + {a} = {r}");
#endif
                                    break;
                                case '-':
                                    a = Convert.ToDouble(al.Pop());
                                    if (al.Count > 0)
                                    {
                                        b = Convert.ToDouble(al.Pop());
                                        r = b - a;
#if DEBUG
                                        Console.WriteLine($"{b} - {a} = {r}");
#endif
                                    } else
                                    {
                                        r = -a;
                                    }
                                    break;
                                case '*':
                                    a = Convert.ToDouble(al.Pop());
                                    b = Convert.ToDouble(al.Pop());
                                    r = a * b;
#if DEBUG
                                    Console.WriteLine($"{b} * {a} = {r}");
#endif

                                    break;
                                case '/':
                                    a = Convert.ToDouble(al.Pop());
                                    b = Convert.ToDouble(al.Pop());
                                    r = (b / a);

#if DEBUG
                                    Console.WriteLine($"{b} / {a} = {r}");
#endif
                                    break;
                                case '^':
                                    a = Convert.ToDouble(al.Pop());
                                    b = Convert.ToDouble(al.Pop());
                                    r = Math.Pow(b, a);
#if DEBUG
                                    Console.WriteLine($"{b} ^ {a} = {r}");
#endif

                                    break;
                            }
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
