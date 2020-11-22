using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsGenerator
{
    public class TestClassTemplate
    {
        string fileName;
        string innerText;

        public TestClassTemplate(string fileName, string innerText)
        {
            this.fileName = fileName;
            this.innerText = innerText;
        }

        public string FileName
        {
            get { return fileName; }
        }

        public string InnerText
        {
            get { return innerText; }
        }
    }
}
