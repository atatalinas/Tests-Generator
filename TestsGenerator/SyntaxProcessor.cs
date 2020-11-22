using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsGenerator
{
    public class SyntaxProcessor
    {
        SyntaxTree tree;
        SyntaxNode root;
        List<ClassDeclarationSyntax> classes;

        public SyntaxProcessResult Process(string sourceCode)
        {
            tree = CSharpSyntaxTree.ParseText(sourceCode);
            root = tree.GetRoot();
            SyntaxProcessResult syntaxRes = new SyntaxProcessResult(GetClasses());
            return syntaxRes;
        }

        private List<ClassInformation> GetClasses()
        {
            classes = new List<ClassDeclarationSyntax>(root.DescendantNodes().OfType<ClassDeclarationSyntax>());
            List<ClassInformation> result = new List<ClassInformation>();
            foreach (ClassDeclarationSyntax cls in classes)
            {
                string className = cls.Identifier.ToString();
                NamespaceDeclarationSyntax clsParent = (NamespaceDeclarationSyntax)cls.Parent;
                string nmsp = clsParent.Name.ToString();
                List<string> methods = GetMethods(cls);
                result.Add(new ClassInformation(className, nmsp, methods));
            }
            return result;
        }

        private List<string> GetMethods(ClassDeclarationSyntax cls)
        {
            return new List<string>(
                cls.DescendantNodes().OfType<MethodDeclarationSyntax>().
                Where(method => method.Modifiers.
                        Any(modifer => modifer.ToString() == "public"))
                        .Select(element => element.Identifier.ToString()));
        }
    }
}
