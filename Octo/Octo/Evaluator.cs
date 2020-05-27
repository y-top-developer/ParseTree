using System;

namespace Octo
{
    internal class Evaluator
    {
        private readonly ExpressionSyntax _root;

        public Evaluator(ExpressionSyntax root)
        {
            this._root = root;
        }

        public int Evaluate()
        {
            return EvaluateExpression(_root);
        }

        private int EvaluateExpression(SyntaxNode node)
        {
            while (true)
            {
                switch (node)
                {
                    case NumberExpressionSyntax numberExpression:
                        return (int) numberExpression.NumberToken.Value;
                    case BinaryExpressionSyntax binaryExpression:
                    {
                        var left = EvaluateExpression(binaryExpression.Left);
                        var right = EvaluateExpression(binaryExpression.Right);

                        return binaryExpression.OperatorToken.Kind switch
                        {
                            SyntaxKind.PlusToken => left + right,
                            SyntaxKind.MinusToken => left - right,
                            SyntaxKind.StarToken => left * right,
                            SyntaxKind.SlashToken => left / right,
                            _ => throw new Exception($"Unexpected binary operator {binaryExpression.Kind}")
                        };
                    }
                    case ParenthesizedExpressionSyntax parenthesized:
                        node = parenthesized.Expression;
                        continue;
                    default:
                        throw new Exception($"Unexpected node {node.Kind}");
                }
            }
        }
    }
}