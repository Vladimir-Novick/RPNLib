using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.sgcombo.RpnLib
{
    internal class RPNEnvironment
    {
        private SortedList<string, Type> functionList = new SortedList<string, Type>();

        public SortedList<string, Type> FunctionList
        {
            get { return functionList; }
        }

        public void RegisterFunction(Type funcType)
        {
            FunctionAttribute funcAttrib = (FunctionAttribute)Attribute.GetCustomAttribute(funcType, typeof(FunctionAttribute));
            functionList.Add(funcAttrib.FunctionName.ToUpper(), funcType);
        }

        public virtual void CalcDataField(string fieldName, ref object value)
        {
            throw new Exception("Can't find DataField " + fieldName + ".");
        }

        public RPNFunction FindFunction(string func)
        {
            int index = functionList.IndexOfKey(func);

            if (index > -1)
            {
                Assembly assembly = Assembly.GetAssembly(functionList.Values[index]);
                RPNFunction rpnFunc = assembly.CreateInstance(functionList.Values[index].FullName) as RPNFunction;

                return rpnFunc;
            }
            else
            {
                return null;
            }
        }
    }
}
