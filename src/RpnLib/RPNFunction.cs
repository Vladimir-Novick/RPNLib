using System;
using System.Collections.Generic;
using System.Globalization;

namespace com.sgcombo.RpnLib
{

    public abstract class RPNFunction
    {
        public abstract object Calc();
        public List<object> Params = new List<object>();
        public override string ToString()
        {
            FunctionAttribute funcAttrib = (FunctionAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(FunctionAttribute));
            return funcAttrib.FunctionName;
        }

        protected bool IsNumeric(object value)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            string str = Convert.ToString(value, provider);
            Double result;
            return Double.TryParse(str, NumberStyles.Integer | NumberStyles.AllowThousands,
                CultureInfo.CurrentCulture, out result);
        }
    }
}
