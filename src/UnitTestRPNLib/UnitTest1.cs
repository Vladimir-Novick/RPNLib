using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace com.sgcombo.RpnLib
{
    [TestClass]
    public class StringTest
    {
        [TestMethod]
        public void SimpleString()
        {
            var compiler = new RPNExpression("'aaaaa'");
            Console.WriteLine("Source string: " + compiler.GetSourceString());
            var RPNString = compiler.Prepare();
            Console.WriteLine($"RPNString : {RPNString}");
            var rezult = compiler.Calculate().ToString();
            Console.WriteLine("Rezult  " + rezult);
            Assert.IsTrue(rezult.Equals("aaaaa"));
        }
    }
    [TestClass]
    public class TestLogical
    {
        [TestMethod]
        public void AND_False()
        {
            String sourceString = "true && false";
            UnitTestUtils.TestExpression(sourceString, "False");
        }

        [TestMethod]
        public void AND_True()
        {
            String sourceString = "true && true";
            UnitTestUtils.TestExpression(sourceString, "True");
        }

        [TestMethod]
        public void OR_True()
        {
            String sourceString = "true || false";
            UnitTestUtils.TestExpression(sourceString, "True");
        }

        [TestMethod]
        public void OR_False()
        {
            String sourceString = "false || false";
            UnitTestUtils.TestExpression(sourceString, "False");
        }


        [TestMethod]
        public void Equalent()
        {
            String sourceString = "5 = 5";
            UnitTestUtils.TestExpression(sourceString, "True");
        }

        [TestMethod]
        public void Equalent2()
        {
            String sourceString = "5 == 5";
            UnitTestUtils.TestExpression(sourceString, "True");
        }

        [TestMethod]
        public void Greater_TRUE()
        {
            String sourceString = "5 > 4";
            UnitTestUtils.TestExpression(sourceString, "True");
        }
        [TestMethod]
        public void Greater_FALSE()
        {
            String sourceString = "4 > 5";
            UnitTestUtils.TestExpression(sourceString, "False");
        }

        [TestMethod]
        public void GreaterOrEqual_TRUE()
        {
            String sourceString = "5 >= 4";
            UnitTestUtils.TestExpression(sourceString, "True");
        }
        [TestMethod]
        public void GreaterOrEqual_FALSE()
        {
            String sourceString = "4 >= 5";
            UnitTestUtils.TestExpression(sourceString, "False");
        }

        [TestMethod]
        public void GreaterOrEqual3_TRUE()
        {
            String sourceString = "5 >= 5";
            UnitTestUtils.TestExpression(sourceString, "True");
        }


        [TestMethod]
        public void GreaterOrEqual4_TRUE()
        {
            String sourceString = "5 ≥ 5";
            UnitTestUtils.TestExpression(sourceString, "True");
        }

        [TestMethod]
        public void GreaterOrEqual2_TRUE()
        {
            String sourceString = "5 ≥ 4";
            UnitTestUtils.TestExpression(sourceString, "True");
        }
        [TestMethod]
        public void GreaterOrEqual2_FALSE()
        {
            String sourceString = "4 ≥ 5";
            UnitTestUtils.TestExpression(sourceString, "False");
        }

        [TestMethod]
        public void Less_TRUE()
        {
            String sourceString = "4 < 5";
            UnitTestUtils.TestExpression(sourceString, "True");
        }
        [TestMethod]
        public void Less_FALSE()
        {
            String sourceString = "5 < 4";
            UnitTestUtils.TestExpression(sourceString, "False");
        }

        [TestMethod]
        public void LessOrEqual_TRUE()
        {
            String sourceString = "4 <= 5";
            UnitTestUtils.TestExpression(sourceString, "True");
        }
        [TestMethod]
        public void LessOrEqual_FALSE()
        {
            String sourceString = "5 <= 4";
            UnitTestUtils.TestExpression(sourceString, "False");
        }

        [TestMethod]
        public void LessOrEqual2_TRUE()
        {
            String sourceString = "4 ≤ 5";
            UnitTestUtils.TestExpression(sourceString, "True");
        }

        [TestMethod]
        public void LessOrEqual3_TRUE()
        {
            String sourceString = "5 ≤ 5";
            UnitTestUtils.TestExpression(sourceString, "True");
        }

        [TestMethod]
        public void LessOrEqual2_FALSE()
        {
            String sourceString = "5 ≤ 4";
            UnitTestUtils.TestExpression(sourceString, "False");
        }

    }
    public class UnitTestUtils
    {
        public static void TestExpression(string sourceString, string verify = null)
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
                Assert.IsTrue(rezult.ToString().Equals(verify.ToString()));
            }
        }

    }
    [TestClass]
    public class Mathematical
    {

        [TestMethod]
        public void ToDoubleTest()
        {
            List<string> inputs = new List<string>()
{
    "1.234.567,89",
    "1 234 567,89",
    "1 234 567.89",
    "1,234,567.89",
    "123456789",
    "1234567,89",
    "1234567.89",
     "123ffff4567.89",
};
            foreach (string input in inputs)
            {
                double d;
                bool ok;
                ok = TryToDouble(input, out d);
                if (ok)
                {
                    Console.WriteLine("OK >" + d);
                }
                else
                {
                    Console.WriteLine("failed >" + input);
                }
            }
        }

        public static bool TryToDouble(string input, out double d)
        {

            // Unify string (no spaces, only .)
            string output = input.Trim().Replace(" ", "").Replace(",", ".");

            // Split it on points
            string[] split = output.Split('.');

            if (split.Length > 1)
            {
                // Take all parts except last
                output = string.Join("", split.Take(split.Length - 1).ToArray());

                // Combine token parts with last part
                output = string.Format("{0}.{1}", output, split.Last());
            }

            // Parse double invariant
            bool ret = double.TryParse(output, NumberStyles.Any, CultureInfo.InvariantCulture, out d);
            return ret;
        }




        [TestMethod]
        public void TestMethod1()
        {
            String sourceString = "4/12*100+(2*7)";
            UnitTestUtils.TestExpression(sourceString, "47.3333333333333");
        }

        [TestMethod]
        public void TestMethod2()
        {
            String sourceString = "((15 / (7 - (1 + 1))) * 3) - (2 + (1 + 1)) ";
            UnitTestUtils.TestExpression(sourceString, "5");
        }


        [TestMethod]
        public void ACOS()
        {
            String sourceString = "ACOS(-1)";
            UnitTestUtils.TestExpression(sourceString, "3.14159265358979");
        }


        [TestMethod]
        public void ACOS_Mathematical()
        {
            String sourceString = "ACOS(-(0.5+0.5)) -20 +5";
            UnitTestUtils.TestExpression(sourceString, "-11.8584073464102");
        }

        [TestMethod]
        public void DATE_Plus()
        {
            String verifyDate = (DateTime.Today.AddHours(24)).ToString();
            String sourceString = "DATE()+24";
            UnitTestUtils.TestExpression(sourceString,verifyDate);
        }

        [TestMethod]
        public void DATE_Minus()
        {
            String verifyDate = (DateTime.Today.AddHours(-24)).ToString();
            String sourceString = "DATE()-24";
            UnitTestUtils.TestExpression(sourceString, verifyDate);
        }


        [TestMethod]
        public void ArgumentList()
        {
            var compiler = new RPNExpression("4/12*100+(A*B)");
            Console.WriteLine("Source string: " + compiler.GetSourceString());
            var RPNString = compiler.Prepare();
            Console.WriteLine($"RPNString : {RPNString}");

            var arg = compiler.GetCalcArguments();

            foreach (var p in arg)
            {
                Console.WriteLine("argument:  <" + p + ">");
            }

            List<RPNArguments> arguments = new List<RPNArguments>();
            arguments.Add(new RPNArguments("A", 2));
            arguments.Add(new RPNArguments("B", 7));
            var rezult = compiler.Calculate(arguments).ToString();
            Console.WriteLine("Rezult  " + rezult);
            Assert.IsTrue("47.3333333333333" == rezult);
        }


        [TestMethod]
        public void Alias()
        {
            var compiler = new RPNExpression("4/12*100+(:A*:B)");
            Console.WriteLine("Source string: " + compiler.GetSourceString());
            var RPNString = compiler.Prepare();
            Console.WriteLine($"RPNString : {RPNString}");

            var arg = compiler.GetCalcArguments();

            foreach (var p in arg)
            {
                Console.WriteLine("argument:  <" + p + ">");
            }

            List<RPNArguments> arguments = new List<RPNArguments>();
            arguments.Add(new RPNArguments(":A", 2));
            arguments.Add(new RPNArguments(":B", 7));
            var rezult = compiler.Calculate(arguments).ToString();
            Console.WriteLine("Rezult  " + rezult);
            Assert.IsTrue("47.3333333333333" == rezult);
        }

        [TestMethod]
        public void Alias2()
        {
            var compiler = new RPNExpression("4/12*100+([:A]*[B])");
            Console.WriteLine("Source string: " + compiler.GetSourceString());
            var RPNString = compiler.Prepare();
            Console.WriteLine($"RPNString : {RPNString}");

            var arg = compiler.GetCalcArguments();

            foreach (var p in arg)
            {
                Console.WriteLine("argument:  <" + p + ">");
            }

            List<RPNArguments> arguments = new List<RPNArguments>();
            arguments.Add(new RPNArguments("[:A]", 2));
            arguments.Add(new RPNArguments("[B]", 7));
            var rezult = compiler.Calculate(arguments).ToString();
            Console.WriteLine("Rezult  " + rezult);
            Assert.IsTrue("47.3333333333333" == rezult);
        }


        [TestMethod]
        public void JustMinus()
        {
            var compiler = new RPNExpression("12+-12");
            Console.WriteLine("Source string: " + compiler.GetSourceString());
            var RPNString = compiler.Prepare();
            Console.WriteLine($"RPNString : {RPNString}");

            var rezult = compiler.Calculate().ToString();
            Console.WriteLine("Rezult  " + rezult);
        }

        [TestMethod]
        public void JustMinusOnly()
        {
            var compiler = new RPNExpression("-12");
            Console.WriteLine("Source string: " + compiler.GetSourceString());
            var RPNString = compiler.Prepare();
            Console.WriteLine($"RPNString : {RPNString}");

            var rezult = compiler.Calculate().ToString();
            Console.WriteLine("Rezult  " + rezult);
        }

        [TestMethod]
        public void JustMinusAndArifmetical ()
        {
            var compiler = new RPNExpression("-12+12");
            Console.WriteLine("Source string: " + compiler.GetSourceString());
            var RPNString = compiler.Prepare();
            Console.WriteLine($"RPNString : {RPNString}");

            var rezult = compiler.Calculate().ToString();
            Console.WriteLine("Rezult  " + rezult);
        }

        [TestMethod]
        public void JustMinus2()
        {
            var compiler = new RPNExpression("-(12+12)");
            Console.WriteLine("Source string: " + compiler.GetSourceString());
            var RPNString = compiler.Prepare();
            Console.WriteLine($"RPNString : {RPNString}");

            var rezult = compiler.Calculate().ToString();
            Console.WriteLine("Rezult  " + rezult);
        }

        [TestMethod]
        public void JustMinus3()
        {
            var compiler = new RPNExpression("-(-12+12)");
            Console.WriteLine("Source string: " + compiler.GetSourceString());
            var RPNString = compiler.Prepare();
            Console.WriteLine($"RPNString : {RPNString}");

            var rezult = compiler.Calculate().ToString();
            Console.WriteLine("Rezult  " + rezult);
        }

        [TestMethod]
        public void JustMinus4()
        {
            var compiler = new RPNExpression("-(-11+12)");
            Console.WriteLine("Source string: " + compiler.GetSourceString());
            var RPNString = compiler.Prepare();
            Console.WriteLine($"RPNString : {RPNString}");

            var rezult = compiler.Calculate().ToString();
            Console.WriteLine("Rezult  " + rezult);
        }
    }
}
