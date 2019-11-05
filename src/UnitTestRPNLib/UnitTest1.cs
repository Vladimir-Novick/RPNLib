using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace com.sgcombo.RpnLib
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            String sourceString = "4/12*100+(2*7)";
            TestExpression(sourceString, "47.3333333333");
        }

        [TestMethod]
        public void TestMethod2()
        {
            String sourceString = "((15 / (7 - (1 + 1))) * 3) - (2 + (1 + 1)) ";
            TestExpression(sourceString, "5");
        }

        private static void TestExpression(string sourceString,string verify = null)
        {
            var compiler = new RPNExpression(sourceString);
            Console.WriteLine("Source string: " + compiler.GetSourceString());
            var RPNString = compiler.Prepare();
            Console.WriteLine($"RPNString : {RPNString}");
            var rezult = compiler.Calculate().ToString();
            Console.WriteLine("Rezult  " + rezult);
            if (verify != null)
            {
                Console.WriteLine("verify  " + verify);
            }
        }

        [TestMethod]
        public void TestMethodVar()
        {
            var compiler = new RPNExpression("4/12*100+(A*B)");
            Console.WriteLine("Source string: " + compiler.GetSourceString());
            var RPNString = compiler.Prepare();
            Console.WriteLine($"RPNString : {RPNString}");

            List<RPNArguments> arguments = new List<RPNArguments>();
            arguments.Add(new RPNArguments("A", 2));
            arguments.Add(new RPNArguments("B", 7));
            var rezult = compiler.Calculate(arguments).ToString();
            Console.WriteLine("Rezult  " + rezult);
        }
    }
}
