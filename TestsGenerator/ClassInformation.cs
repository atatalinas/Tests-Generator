using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsGenerator
{
    public class ClassInformation
    {
        string name;
        string namespaceName;
        List<string> methods;

        public ClassInformation(string name, string nsName, List<string> methods)
        {
            this.name = name;
            this.namespaceName = nsName;
            this.methods = new List<string>(methods);
        }

        public string Name => name;
        public string NamespaceName => namespaceName;
        public List<string> Methods
        {
            get
            {
                return methods;
            }
            set
            {
                methods = new List<string>(value);
            }
        }
    }
}
