using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsGenerator.Tests
{
    [TestClass]
    public class TestsGeneratorTests
    {
        string resultPath;
        private AsyncFileWriter asyncWriter;
        private List<string> files;
        private int maxReadableCount;
        private int maxProcessableCount;
        private int maxWritableCount;
        private TestGenerator testsGenerator;

        [TestInitialize]
        public void SetUp()
        {
            resultPath = Environment.CurrentDirectory + "\\Result";
            asyncWriter = new AsyncFileWriter(resultPath);

            files = new List<string>();
            string pathToFile1 = Environment.CurrentDirectory + "\\Source\\Class.cs";
            files.Add(pathToFile1);

            maxReadableCount = 3;
            maxProcessableCount = 3;
            maxWritableCount = 3;
            testsGenerator = new TestGenerator(files, maxReadableCount, maxProcessableCount, maxWritableCount);
        }

        [TestMethod]
        public void GenerateTest()
        {
            int prevCountofFiles = Directory.GetFiles(resultPath).Length;
            testsGenerator.Generate(asyncWriter).Wait();
            int currentCountOfFiles = Directory.GetFiles(resultPath).Length;
            int expectedCount = prevCountofFiles + files.Count;
            Assert.AreEqual(expectedCount, currentCountOfFiles);
            foreach (string filePath in files)
            {
                string pathToResFile = resultPath + "\\" + Path.GetFileNameWithoutExtension(filePath) + "Tests.cs";
                File.Delete(pathToResFile);
            }
        }
    }
}
