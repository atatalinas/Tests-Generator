using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsGenerator
{
    public class TestsGenerator
    {
        private int maxReadFilesCount;
        private int maxProcessTasksCount;
        private int maxWriteFilesCount;
        private List<string> fileNames;

        public TestsGenerator(List<string> fileNames, int maxReadableCount, int maxProcessCount, int maxWritableCount)
        {
            this.fileNames = new List<string>(fileNames);
            this.maxReadFilesCount = maxReadableCount;
            this.maxProcessTasksCount = maxProcessCount;
            this.maxWriteFilesCount = maxWritableCount;
        }

        public async Task Generate()
        {

        }
    }
}
