using System.Collections.Generic;

namespace ParseTree.Syntax
{
    internal sealed class LiteralExpressionSyntax : ExpressionSyntax
    {
        public SyntaxToken LiteralToken { get; }

        public LiteralExpressionSyntax(SyntaxToken literalToken)
        {
            LiteralToken = literalToken;
        }

        public override SyntaxKind Kind => SyntaxKind.LiteralExpression;

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            yield return LiteralToken;
        }
    }
}