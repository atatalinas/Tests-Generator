using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsGenerator.Tests
{
    [TestClass]
    public class SyntaxProcessorTests
    {
        private string pathToFile;
        private AsyncFileReader asyncReader;
        private SyntaxProcessor syntaxProcessor;
        private SyntaxProcessResult syntaxProcessResult;
        private SyntaxNode root;

        [TestInitialize]
        public void SetUp()
        {
            pathToFile = Environment.CurrentDirectory + "\\Source\\Class.cs";
            asyncReader = new AsyncFileReader();
            string sourceCode = asyncReader.Read(pathToFile).Result;

            syntaxProcessor = new SyntaxProcessor();
            syntaxProcessResult = syntaxProcessor.Process(sourceCode);

            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);
            root = syntaxTree.GetRoot();
        }

        [TestMethod]
        public void ProcessTest()
        {
            List<ClassInformation> classes = syntaxProcessResult.Classes;
            foreach (ClassInformation cls in classes)
            {
                List<ClassDeclarationSyntax> sameClasses = new List<ClassDeclarationSyntax>(root.DescendantNodes().OfType<ClassDeclarationSyntax>()
                    .Where((classInfo) =>
                    (classInfo.Identifier.ToString() == cls.Name)
                    && (((NamespaceDeclarationSyntax)classInfo.Parent).Name.ToString() == cls.NamespaceName)));
                Assert.AreNotEqual(sameClasses.Count, 0);
            }
        }
    }
}
