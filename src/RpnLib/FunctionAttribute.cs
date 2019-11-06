using System;

namespace com.sgcombo.RpnLib
{
    internal class FunctionAttribute : Attribute
    {
        private string functionName;
        private string paramTypes;
        private string group;
        private string paramNames;
        private string description;

        public string FunctionName
        {
            get { return functionName; }
            set { functionName = value; }
        }

        public string ParamTypes
        {
            get { return paramTypes; }
            set { paramTypes = value; }
        }

        public string Group
        {
            get { return group; }
            set { group = value; }
        }


        public FunctionAttribute(string functionName)
        {
            this.functionName = functionName;
        }
    }
}
