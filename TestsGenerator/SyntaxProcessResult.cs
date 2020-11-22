using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsGenerator
{
    public class SyntaxProcessResult
    {
        List<string> classNames;
        List<string> methodNames;

        public List<string> ClassNames
        {
            get
            {
                return classNames;
            }
            set
            {
                classNames = new List<string>(value);
            }
        }

        public List<string> MethodNames
        {
            get
            {
                return methodNames;
            }
            set
            {
                methodNames = new List<string>(value);
            }
        }
    }
}
