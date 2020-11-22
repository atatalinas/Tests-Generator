using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsGenerator
{
    public class TestsGenerator
    {
        private uint maxReadFilesCount;
        private uint maxProcessTasksCount;
        private uint maxWriteFilesCount;
        private List<string> fileNames;

        public TestsGenerator(List<string> fileNames, uint maxReadableCount, uint maxProcessCount, uint maxWritableCount)
        {
            this.fileNames = new List<string>(fileNames);
            this.maxReadFilesCount = maxReadableCount;
            this.maxProcessTasksCount = maxProcessCount;
            this.maxWriteFilesCount = maxWritableCount;
        }

        public void Generate()
        {

        }
    }
}
