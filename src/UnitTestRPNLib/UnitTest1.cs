using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Text;

namespace com.sgcombo.RpnLib
{
    [TestClass]
    public class RPNExpressionTest
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


    public struct RPNArgumentStruct
    {
        public string Name;
        public string Value;

        public RPNArgumentStruct(string _Name, string _Value)
        {
            Name = _Name;
            Value = _Value;
        }

    }
    public class RPNArgumentClass
    {
        public string Name;
        public string Value;

        public RPNArgumentClass(string _Name, string _Value)
        {
            Name = _Name;
            Value = _Value;
        }

    }



    [TestClass]
    public class PerformenceTest
    {

    private static void TestStringIndexOf(string input, StringComparison stringComparison)
    {
        var count = 0;
            Stopwatch sw;
            sw = Stopwatch.StartNew();

            for (var index = 0; index != 1000000; index++)
        {
            count = input.IndexOf("<script", 0, stringComparison);
        }

            sw.Stop();
           

        Console.WriteLine("{0}", stringComparison);
        Console.WriteLine("Total time: {0:N0}", sw.ElapsedMilliseconds);
        Console.WriteLine("--------------------------------");
    }

        private static void TestStringIndexOf_NotStart(string input, StringComparison stringComparison)
        {
            var count = 0;
            Stopwatch sw;
            sw = Stopwatch.StartNew();

            for (var index = 0; index != 1000000; index++)
            {
                count = input.IndexOf("<script", stringComparison);
            }

            sw.Stop();


            Console.WriteLine("{0} not start 0", stringComparison);
            Console.WriteLine("Total time: {0:N0}", sw.ElapsedMilliseconds);
            Console.WriteLine("--------------------------------");
        }


        private static void TestStringIndexOf_default(string input)
        {
            var count = 0;
            Stopwatch sw;
            sw = Stopwatch.StartNew();

            for (var index = 0; index != 1000000; index++)
            {
                count = input.IndexOf("<script");
            }

            sw.Stop();


            Console.WriteLine("Defailt StringOf");
            Console.WriteLine("Total time: {0:N0}", sw.ElapsedMilliseconds);
            Console.WriteLine("--------------------------------");
        }



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
                ok = TryToDouble6(input, out d);
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

        public static bool TryToDouble3(string input, out double d)
        {

            // Unify string (no spaces, only .)
            string output = input.Replace(" ", String.Empty).Replace(',', '.');

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

        public static bool TryToDouble5(string input, out double d)
        {

            // Unify string (no spaces, only .)
            string output = input.Replace(',', '.');

            if (output.IndexOf(' ') != -1)
            {
                output = output.Replace(" ", String.Empty);
            }

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

        public static bool TryToDouble6(string input, out double d)
        {
            bool isSpace = false;
            bool isComma = false;
            int countPoint = 0;
            int l = input.Length;
            char ch;
            for (int j = 0; j < l; j++)
            {
                ch = input[j];
                if (ch == ' ') isSpace = true;
                else
                if (ch == ',')
                {
                    isComma = true;
                    countPoint++;
                }
                else
                if (ch == '.')
                {
                    countPoint++;
                }
            }

            // Unify string (no spaces, only .)
            string output = input;
            if (isComma)
            {
                output = output.Replace(',', '.');
            }

            if (isSpace)
            {
                output = output.Replace(" ", String.Empty);
            }


            if (countPoint > 1)
            {
                // Split it on points
                string[] split = output.Split('.');

                // Take all parts except last
                output = string.Join("", split.Take(split.Length - 1).ToArray());

                // Combine token parts with last part
                output = string.Format("{0}.{1}", output, split.Last());
            }

            // Parse double invariant
            bool ret = double.TryParse(output, NumberStyles.Any, CultureInfo.InvariantCulture, out d);
            return ret;
        }

        public static bool TryToDouble4(string input, out double d)
        {

            // Unify string (no spaces, only .)
            string output = input.Replace(" ", String.Empty).Replace(',', '.');

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
            d = Convert.ToDouble(output);
            return true;
        }


        public static bool TryToDouble2(string input, out double d)
        {

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                // Unify string (no spaces, only .)
                if (input[i] != ' ')
                {
                    if (input[i] == ',') sb.Append('.');
                    else sb.Append(input[i]);
                }

            }
            string output = sb.ToString();
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
        public void ToDouble_PerformenceTest()
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
                ok = TryToDouble6(input, out d);
                if (ok)
                {
                    Console.WriteLine("OK >" + d);
                }
                else
                {
                    Console.WriteLine("failed >" + input);
                }
            }

            {
                Stopwatch sw;
                sw = Stopwatch.StartNew();
                const int PermittedRuns = 10000000;

                for (int i = 0; i < PermittedRuns; i++)
                {
                    double d;
                    bool ok;
                    ok = TryToDouble("1.234.567,89", out d);
                }

                sw.Stop();
                Console.WriteLine(String.Format("try to double = {0:N0} Milliseconds of PermittedRuns {1:N0} ", sw.ElapsedMilliseconds, PermittedRuns));
            }

            {
                Stopwatch sw;
                sw = Stopwatch.StartNew();
                const int PermittedRuns = 10000000;

                for (int i = 0; i < PermittedRuns; i++)
                {
                    double d;
                    bool ok;
                    ok = TryToDouble2("1.234.567,89", out d);
                }

                sw.Stop();
                Console.WriteLine(String.Format("try to double2 = {0:N0} Milliseconds of PermittedRuns {1:N0} ", sw.ElapsedMilliseconds, PermittedRuns));
            }

            {
                Stopwatch sw;
                sw = Stopwatch.StartNew();
                const int PermittedRuns = 10000000;

                for (int i = 0; i < PermittedRuns; i++)
                {

                    var ok = "1.234.567,89".Replace(",", ".");
                }

                sw.Stop();
                Console.WriteLine(String.Format("retplace string = {0:N0} Milliseconds of PermittedRuns {1:N0} ", sw.ElapsedMilliseconds, PermittedRuns));
            }

            {
                Stopwatch sw;
                sw = Stopwatch.StartNew();
                const int PermittedRuns = 10000000;

                for (int i = 0; i < PermittedRuns; i++)
                {

                    var ok = "1.234.567,89".Replace(',', '.');
                }

                sw.Stop();
                Console.WriteLine(String.Format("retplace char = {0:N0} Milliseconds of PermittedRuns {1:N0} ", sw.ElapsedMilliseconds, PermittedRuns));
            }


            {
                Stopwatch sw;
                sw = Stopwatch.StartNew();
                const int PermittedRuns = 10000000;

                for (int i = 0; i < PermittedRuns; i++)
                {
                    double d;
                    bool ok;
                    ok = TryToDouble3("1.234.567,89", out d);
                }

                sw.Stop();
                Console.WriteLine(String.Format("try to double3 = {0:N0} Milliseconds of PermittedRuns {1:N0} ", sw.ElapsedMilliseconds, PermittedRuns));
            }

            {
                Stopwatch sw;
                sw = Stopwatch.StartNew();
                const int PermittedRuns = 10000000;

                for (int i = 0; i < PermittedRuns; i++)
                {
                    double d;
                    bool ok;
                    ok = TryToDouble5("1.234.567,89", out d);
                }

                sw.Stop();
                Console.WriteLine(String.Format("try to double5 = {0:N0} Milliseconds of PermittedRuns {1:N0} ", sw.ElapsedMilliseconds, PermittedRuns));
            }

            {
                Stopwatch sw;
                sw = Stopwatch.StartNew();
                const int PermittedRuns = 10000000;

                for (int i = 0; i < PermittedRuns; i++)
                {
                    double d;
                    bool ok;
                    ok = TryToDouble4("1.234.567,89", out d);
                }

                sw.Stop();
                Console.WriteLine(String.Format("try to double4 = {0:N0} Milliseconds of PermittedRuns {1:N0} ", sw.ElapsedMilliseconds, PermittedRuns));
            }



        }
        [TestMethod]
        public void ToDouble6_test()
        {
            {
                Stopwatch sw;
                sw = Stopwatch.StartNew();
                const int PermittedRuns = 10000000;

                for (int i = 0; i < PermittedRuns; i++)
                {
                    double d;
                    bool ok;
                    ok = TryToDouble6("1.234.567,89", out d);
                }

                sw.Stop();
                Console.WriteLine(String.Format("try to double6  {0:N0} - 1.234.567,89 -Milliseconds of PermittedRuns {1:N0} ", sw.ElapsedMilliseconds, PermittedRuns));
            }

            {
                Stopwatch sw;
                sw = Stopwatch.StartNew();
                const int PermittedRuns = 10000000;

                for (int i = 0; i < PermittedRuns; i++)
                {
                    double d;
                    bool ok;
                    ok = TryToDouble6("1234567,89", out d);
                }

                sw.Stop();
                Console.WriteLine(String.Format("try to double6  {0:N0} - 1234567,89 - Milliseconds of PermittedRuns {1:N0} ", sw.ElapsedMilliseconds, PermittedRuns));
            }
        }

        [TestMethod]
        public void Convert_ToDouble()
        {
            const int Iterations = 1000000;
            {
                double d = 10;
                object dobj = d;
                double d1 = 0;
                Stopwatch sw = Stopwatch.StartNew();
                for (int i = 0; i < Iterations; i++)
                {
                    d1 = Convert.ToDouble(dobj);
                }
                sw.Stop();
                Console.WriteLine("Convert.ToDouble : {0} ticks {1} ms", sw.ElapsedTicks, sw.ElapsedMilliseconds);
            }

            {
                double d = 10;
                object o = d;
                Double ? d1 = 0;
                Stopwatch sw = Stopwatch.StartNew();
                for (int i = 0; i < Iterations; i++)
                {
                    d1 = (o is double) ? (double)o
            : (o is IConvertible) ? (o as IConvertible).ToDouble(null)
            : double.Parse(o.ToString());

                }
                sw.Stop();
                Console.WriteLine("is double : {0} ticks {1} ms", sw.ElapsedTicks, sw.ElapsedMilliseconds);
            }

        }

        [TestMethod]
        public void TypeOfTest()
        {
            const int Iterations = 1000000;
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < Iterations; i++)
            {
                Type t = typeof(String);
            }
            sw.Stop();
            Console.WriteLine("typeof(Test): {0} ticks {1} ms", sw.ElapsedTicks, sw.ElapsedMilliseconds);

            sw = Stopwatch.StartNew();
            for (int i = 0; i < Iterations; i++)
            {
                Type t = System.Type.GetType("System.String");
            }
            sw.Stop();
            Console.WriteLine("Type.GetType(String): {0} ticks {1} ms", sw.ElapsedTicks, sw.ElapsedMilliseconds);

            {
                string str = "String";
                sw = Stopwatch.StartNew();
                for (int i = 0; i < Iterations; i++)
                {
                    Type t = str.GetType();
                }
                sw.Stop();
                Console.WriteLine("String.GetType(): {0} ticks {1} ms", sw.ElapsedTicks, sw.ElapsedMilliseconds);
            }

            {
                string str = "String";
                object strObj = str;
                string str2;
                sw = Stopwatch.StartNew();
                for (int i = 0; i < Iterations; i++)
                {
                    str2 = strObj as string;
                }
                sw.Stop();
                Console.WriteLine("strObj as string : {0} ticks {1} ms", sw.ElapsedTicks, sw.ElapsedMilliseconds);
            }
        }

        [TestMethod]
       public  void TryCatchTest()
        {
            var input = "Hello world, This is test string";
            {
                var count = 0;
                Stopwatch sw;
                sw = Stopwatch.StartNew();

                for (var index = 0; index != 1000000; index++)
                {
                    count = input.IndexOf("<script");
                }

                sw.Stop();


                Console.WriteLine("without try cach");
                Console.WriteLine("Total time: {0:N0}", sw.ElapsedMilliseconds);
                Console.WriteLine("--------------------------------");
            }

            {
                var count = 0;
                Stopwatch sw;
                sw = Stopwatch.StartNew();

                for (var index = 0; index != 1000000; index++)
                {
                    try
                    {
                        count = input.IndexOf("<script");
                    }
                    catch
                    {
                    }
                }

                sw.Stop();


                Console.WriteLine("using try catch");
                Console.WriteLine("Total time: {0:N0}", sw.ElapsedMilliseconds);
                Console.WriteLine("--------------------------------");
            }
        }

        [TestMethod]
        public void StringIndexOfTest()
        {

            var input = "Hello world, This is test string";


            TestStringIndexOf_default(input);

            TestStringIndexOf(input,          StringComparison.CurrentCulture);
            TestStringIndexOf_NotStart(input, StringComparison.CurrentCulture);
            Console.WriteLine("");

            TestStringIndexOf(input,          StringComparison.InvariantCulture);
            TestStringIndexOf_NotStart(input, StringComparison.InvariantCulture);
            Console.WriteLine("");

            TestStringIndexOf(input,          StringComparison.Ordinal);
            TestStringIndexOf_NotStart(input, StringComparison.Ordinal);
            Console.WriteLine("");

            TestStringIndexOf(input,          StringComparison.OrdinalIgnoreCase);
            TestStringIndexOf_NotStart(input, StringComparison.OrdinalIgnoreCase);

        }

        [TestMethod]
        public void StartWichTest()
        {

            const int PermittedRuns = 1000000;
            string str = "1234567] [ wertyuiopa] [ sdfghjkl] ;zxcvbnm,.";

            {
                Stopwatch sw;
                sw = Stopwatch.StartNew();

                for (int i = 0; i < PermittedRuns; i++)
                {
                    var p = str.StartsWith("1234567");
                }

                sw.Stop();
                Console.WriteLine(String.Format("string StartsWith = {0:N0} Milliseconds of PermittedRuns {1:N0} ", sw.ElapsedMilliseconds, PermittedRuns));
            }

            {
                Stopwatch sw;
                sw = Stopwatch.StartNew();

                for (int i = 0; i < PermittedRuns; i++)
                {
                    var p = str.StartsWith("1234567", StringComparison.Ordinal);
                }

                sw.Stop();
                Console.WriteLine(String.Format("string StartsWith = {0:N0} Milliseconds of PermittedRuns {1:N0} StringComparison.Ordinal ", sw.ElapsedMilliseconds, PermittedRuns));
            }
        }

        [TestMethod]
        public void StartWich_IsPrefix_Test()
        {

            const int PermittedRuns = 1000000;
            string str = "1234567] [ wertyuiopa] [ sdfghjkl] ;zxcvbnm,.";

            {
                Stopwatch sw;
                sw = Stopwatch.StartNew();

                for (int i = 0; i < PermittedRuns; i++)
                {
                    var p = str.StartsWith("1234567");
                }

                sw.Stop();
                Console.WriteLine(String.Format("string StartsWith = {0:N0} Milliseconds of PermittedRuns {1:N0} ", sw.ElapsedMilliseconds, PermittedRuns));
            }

            {
                Stopwatch sw;
                sw = Stopwatch.StartNew();

                for (int i = 0; i < PermittedRuns; i++)
                {
                    var p = str.StartsWith("1234567",StringComparison.InvariantCultureIgnoreCase);
                }

                sw.Stop();
                Console.WriteLine(String.Format("string StartsWith = {0:N0} ( InvariantCultureIgnoreCase ) Milliseconds of PermittedRuns {1:N0} ", sw.ElapsedMilliseconds, PermittedRuns));
            }

            {
                CompareInfo compareInfo = CultureInfo.InvariantCulture.CompareInfo;
                Stopwatch sw;
                sw = Stopwatch.StartNew();
               

                for (int i = 0; i < PermittedRuns; i++)
                {
                    var p = compareInfo.IsPrefix(str,"1234567");
                }

                sw.Stop();
                Console.WriteLine(String.Format("string StartsWith  = {0:N0} ( IsPrefix ) Milliseconds of PermittedRuns {1:N0} CompareInfo ", sw.ElapsedMilliseconds, PermittedRuns));
            }

            {
                Stopwatch sw;
                sw = Stopwatch.StartNew();
                CompareInfo compareInfo = CultureInfo.InvariantCulture.CompareInfo;

                for (int i = 0; i < PermittedRuns; i++)
                {
                    var p = compareInfo.IsPrefix(str, "1234567", CompareOptions.Ordinal);
                }

                sw.Stop();
                Console.WriteLine(String.Format("string StartsWith = {0:N0} ( IsPrefix - CompareOptions.Ordinal ) Milliseconds of PermittedRuns {1:N0} CompareInfo , CompareOptions.Ordinal ", sw.ElapsedMilliseconds, PermittedRuns));
            }

            {
                Stopwatch sw;
                sw = Stopwatch.StartNew();

                for (int i = 0; i < PermittedRuns; i++)
                {
                    var p = str.StartsWith("1234567", StringComparison.Ordinal);
                }

                sw.Stop();
                Console.WriteLine(String.Format("string StartsWith = {0:N0}  ( StringComparison.Ordinal ) Milliseconds of PermittedRuns {1:N0} StringComparison.Ordinal ", sw.ElapsedMilliseconds, PermittedRuns));
            }

            {
                Stopwatch sw;
                sw = Stopwatch.StartNew();

                for (int i = 0; i < PermittedRuns; i++)
                {
                    var p = str.StartsWith("1234567", StringComparison.InvariantCultureIgnoreCase);
                }

                sw.Stop();
                Console.WriteLine(String.Format("string StartsWith = {0:N0} (  StringComparison.InvariantCultureIgnoreCase ) Milliseconds of PermittedRuns {1:N0} StringComparison.InvariantCultureIgnoreCase ", sw.ElapsedMilliseconds, PermittedRuns));
            }


        }

        [TestMethod]
        public void IndexOfChar_To_Contains()
        {

            const int PermittedRuns = 10000000;
            {
                Stopwatch sw;
                sw = Stopwatch.StartNew();

                string str = "1234567890qwertyuiopasdfghjkl;zxcvbnm,.";

                for (int i = 0; i < PermittedRuns; i++)
                {
                    int p = str.IndexOf(' ');
                }

                sw.Stop();
                Console.WriteLine(String.Format("IndexOfChar = {0:N0} Milliseconds of PermittedRuns {1:N0} ", sw.ElapsedMilliseconds, PermittedRuns));
            }


            {
                Stopwatch sw;
                sw = Stopwatch.StartNew();

                string str = "1234567890qwertyuiopasdfghjkl;zxcvbnm,.";

                for (int i = 0; i < PermittedRuns; i++)
                {
                    int p = str.IndexOf(" ");
                }

                sw.Stop();
                Console.WriteLine(String.Format("IndexOf string = {0:N0} Milliseconds of PermittedRuns {1:N0} ", sw.ElapsedMilliseconds, PermittedRuns));
            }

            {
                Stopwatch sw;
                sw = Stopwatch.StartNew();

                string str = "1234567890qwertyuiopasdfghjkl;zxcvbnm,.";

                for (int i = 0; i < PermittedRuns; i++)
                {
                    int p = str.IndexOf(" ",StringComparison.Ordinal);
                }

                sw.Stop();
                Console.WriteLine(String.Format("IndexOf string ( StringComparison.Ordinal ) = {0:N0} Milliseconds of PermittedRuns {1:N0} ", sw.ElapsedMilliseconds, PermittedRuns));
            }

            {
                Stopwatch sw;
                sw = Stopwatch.StartNew();

                string str = "1234567890qwertyuiopasdfghjkl;zxcvbnm,.";

                for (int i = 0; i < PermittedRuns; i++)
                {
                    bool p = str.Contains(" ");
                }

                sw.Stop();
                Console.WriteLine(String.Format("contains = {0:N0} Milliseconds of PermittedRuns  {1:N0} ", sw.ElapsedMilliseconds, PermittedRuns));
            }


        }


            [TestMethod]
        public void IndexOfChar_To_indexOFString()
        {

            const int PermittedRuns = 10000000;
            {
                Stopwatch sw;
                sw = Stopwatch.StartNew();

                string str = "1234567890qwertyuiopasdfghjkl;zxcvbnm,.";

                for (int i = 0; i < PermittedRuns; i++)
                {
                    int p = str.IndexOf(' ');
                }

                sw.Stop();
                Console.WriteLine(String.Format("IndexOfChar = {0:N0} Milliseconds of PermittedRuns {1:N0} ", sw.ElapsedMilliseconds, PermittedRuns));
            }

            {
                Stopwatch sw;
                sw = Stopwatch.StartNew();

                string str = "1234567890qwertyuiopasdfghjkl;zxcvbnm,.";

                for (int i = 0; i < PermittedRuns; i++)
                {
                    int p = str.IndexOf(" ");
                }

                sw.Stop();
                Console.WriteLine(String.Format("IndexOfString = {0:N0} Milliseconds of PermittedRuns  {1:N0} ", sw.ElapsedMilliseconds, PermittedRuns));
            }


            {
                Stopwatch sw;
                sw = Stopwatch.StartNew();

                string str = "1234567890qwertyuiopasdfghjkl;zxcvbnm,.";

                for (int i = 0; i < PermittedRuns; i++)
                {
                    int p = str.IndexOf(" ", System.StringComparison.Ordinal);
                }

                sw.Stop();
                Console.WriteLine(String.Format("IndexOfString = {0:N0} Milliseconds of PermittedRuns  {1:N0} , System.StringComparison.Ordinal ", sw.ElapsedMilliseconds, PermittedRuns));
            }


        }
    }


            [TestClass]
    public class Mathematical
    {




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
