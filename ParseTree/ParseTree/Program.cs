using System;
using System.Linq;
using ParseTree.Syntax;

namespace ParseTree
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.Write("> ");
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                    return;

                switch (line)
                {
                    case "#clear":
                        Console.Clear();
                        continue;
                }

                var syntaxTree = SyntaxTree.Parse(line);

                Console.ForegroundColor = ConsoleColor.DarkGray;
                PrettyPrint(syntaxTree.Root);
                Console.ResetColor();
                

                if (!syntaxTree.Diagnostics.Any())
                {
                    var evaluator = new Evaluator(syntaxTree.Root);
                    var result = evaluator.Evaluate();
                    Console.WriteLine(result);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    foreach (var diagnostic in syntaxTree.Diagnostics)
                        Console.WriteLine(diagnostic);
                    Console.ResetColor();
                }
            }
        }

        private static void PrettyPrint(SyntaxNode node, string indent = "", bool isLast = true)
        {
            var marker = isLast ? "└──" : "├──";

            Console.Write(indent);
            Console.Write(marker);
            Console.Write(node.Kind);

            if (node is SyntaxToken token && token.Value != null)
            {
                Console.Write(" ");
                Console.Write(token.Value);
            }

            Console.WriteLine();

            indent += isLast ? "    " : "│   ";

            var lastChild = node.GetChildren().LastOrDefault();

            foreach (var child in node.GetChildren())
            {
                PrettyPrint(child, indent, child == lastChild);
            }
        }
    }
}