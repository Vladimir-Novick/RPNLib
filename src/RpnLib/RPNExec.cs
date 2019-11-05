using System;
using System.Collections.Generic;


namespace com.sgcombo.RpnLib
{

    internal class RPNExec
    {

        private List<RPNToken> Tokens = new List<RPNToken>();
        private Stack<object> al;
        private Dictionary<string, RPNArguments> vars = new Dictionary<string, RPNArguments>();

        public RPNExec(List<RPNToken> _Tokens)
        {
            Tokens = _Tokens;
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
                        double r = 0;
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
                                b = Convert.ToDouble(al.Pop());
                                r = b - a;
#if DEBUG
                                Console.WriteLine($"{b} - {a} = {r}");
#endif
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
