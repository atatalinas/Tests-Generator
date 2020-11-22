using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TestsGenerator
{
    public class AsyncFileWriter
    {
        private string outPutDirectory;

        public AsyncFileWriter(string outPutDirectory)
        {
            this.outPutDirectory = outPutDirectory;
        }

        public async Task Write(TestClassTemplate classTemplate)
        {
            if (classTemplate == null)
            {
                return;
            }
            string filePath = outPutDirectory + "\\" + classTemplate.FileName;
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                await writer.WriteAsync(classTemplate.InnerText);
            }
        }
    }
}
