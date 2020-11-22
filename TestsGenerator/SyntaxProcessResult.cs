using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsGenerator
{
    public class SyntaxProcessResult
    {
        List<ClassInformation> classes;

        public SyntaxProcessResult(List<ClassInformation> classes)
        {
            Classes = classes;
        }

        public List<ClassInformation> Classes
        {
            get
            {
                return classes;
            }
            set
            {
                classes = new List<ClassInformation>(value);
            }
        }
    }
}
