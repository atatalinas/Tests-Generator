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
    public class TemplateGeneratorTests
    {
        string pathToFile;
        string sourceCode;
        private AsyncFileReader asyncReader;
        private TestClassTemplate testClassTemplate;
        private TemplateClassGenerator templateGenerator;
        SyntaxNode sourceRoot;
        SyntaxNode generatedRoot;

        [TestInitialize]
        public void SetUp()
        {
            pathToFile = Environment.CurrentDirectory + "\\Source\\Class.cs";
            asyncReader = new AsyncFileReader();
            sourceCode = asyncReader.Read(pathToFile).Result;
            templateGenerator = new TemplateClassGenerator();
            sourceRoot = CSharpSyntaxTree.ParseText(sourceCode).GetRoot();
        }

        [TestMethod]
        public void GetTemplateTest()
        {
            testClassTemplate = templateGenerator.GetTemplate(sourceCode);
            Assert.IsNotNull(testClassTemplate);
            generatedRoot = CSharpSyntaxTree.ParseText(testClassTemplate.InnerText).GetRoot();
            List<ClassDeclarationSyntax> generatedClasses = new List<ClassDeclarationSyntax>(generatedRoot.DescendantNodes().OfType<ClassDeclarationSyntax>());
            List<ClassDeclarationSyntax> sourceClasses = new List<ClassDeclarationSyntax>(sourceRoot.DescendantNodes().OfType<ClassDeclarationSyntax>());
            Assert.AreEqual(sourceClasses.Count, generatedClasses.Count);

            for (int i = 0; i < sourceClasses.Count; i++)
            {
                ClassDeclarationSyntax sourceClass = sourceClasses[i];
                ClassDeclarationSyntax generatedClass = generatedClasses[i];

                List<MethodDeclarationSyntax> sourceMethods = new List<MethodDeclarationSyntax>(
                    sourceClass.DescendantNodes().OfType<MethodDeclarationSyntax>()
                    .Where(method => method.Modifiers.
                        Any(modifer => modifer.ToString() == "public")));
                List<MethodDeclarationSyntax> generatedMethods = new List<MethodDeclarationSyntax>(
                    generatedClass.DescendantNodes().OfType<MethodDeclarationSyntax>()
                    .Where(method => method.Modifiers.
                        Any(modifer => modifer.ToString() == "public")));
                Assert.AreEqual(sourceMethods.Count, generatedMethods.Count);

                for (int j = 0; j < sourceMethods.Count; j++)
                {
                    MethodDeclarationSyntax sourceMethod = sourceMethods[j];
                    MethodDeclarationSyntax generatedMethod = generatedMethods[j];
                    Assert.IsTrue(generatedMethod.Identifier.ToString().Contains(sourceMethod.Identifier.ToString()));
                }
            }
        }
    }
}
