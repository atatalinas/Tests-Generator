using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsGenerator;

namespace UnitTests
{
    [TestClass]
    public class AsyncFileWriterAndReaderTests
    {
        private string pathToFile;
        private string pathToDirectory;
        private string testString;
        private string fileName;
        private TestClassTemplate template;
        private AsyncFileReader asyncReader;
        private AsyncFileWriter asyncWriter;

        [TestInitialize]
        public void SetUp()
        {
            pathToFile = Environment.CurrentDirectory + "\\Result\\Test.cs";
            pathToDirectory = Environment.CurrentDirectory + "\\Result";
            asyncReader = new AsyncFileReader();
            asyncWriter = new AsyncFileWriter(pathToDirectory);
            fileName = "Test.cs";
            testString = "Write and read test!";
            template = new TestClassTemplate(fileName, testString);
        }

        [TestMethod]
        public void WriteAndReadTest()
        {
            asyncWriter.Write(template).Wait();
            string resultStr = asyncReader.Read(pathToFile).Result;
            Assert.IsNotNull(resultStr);
            Assert.AreEqual(testString, resultStr);
            File.Delete(pathToFile);
        }
    }
}
