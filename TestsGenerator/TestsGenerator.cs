using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

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

        public async Task Generate(AsyncFileWriter writer)
        {
            DataflowLinkOptions linkOptions = new DataflowLinkOptions { PropagateCompletion = true };
            ExecutionDataflowBlockOptions maxReadableFilesTasks = new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = maxReadFilesCount
            };

            ExecutionDataflowBlockOptions maxProcessableTasks = new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = maxProcessTasksCount
            };

            ExecutionDataflowBlockOptions maxWritableTasks = new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = maxWriteFilesCount
            };

            AsyncFileReader asyncReader = new AsyncFileReader();
            TemplateClassGenerator templateGenerator = new TemplateClassGenerator();

            TransformBlock<string, string> readingBlock =
                new TransformBlock<string, string>(new Func<string, Task<String>>(asyncReader.Read), maxReadableFilesTasks);

            TransformBlock<string, TestClassTemplate> processingBlock =
                new TransformBlock<string, TestClassTemplate>(new Func<string, TestClassTemplate>(templateGenerator.GetTemplate), maxProcessableTasks);

            ActionBlock<TestClassTemplate> writingBlock = new ActionBlock<TestClassTemplate>(
                (classTemplate) => writer.Write(classTemplate), maxWritableTasks);

            readingBlock.LinkTo(processingBlock, linkOptions);
            processingBlock.LinkTo(writingBlock, linkOptions);

            foreach (string filePath in fileNames)
            {
                readingBlock.Post(filePath);
            }

            readingBlock.Complete();

            await writingBlock.Completion;

        }
    }
}
