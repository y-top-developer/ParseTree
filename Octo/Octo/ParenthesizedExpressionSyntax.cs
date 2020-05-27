using System.Collections.Generic;

namespace Octo
{
    internal sealed class ParenthesizedExpressionSyntax : ExpressionSyntax
    {
        public SyntaxToken OpenParenthesizedToken { get; }
        public ExpressionSyntax Expression { get; }
        public SyntaxToken ClosedParenthesizedToken { get; }

        public ParenthesizedExpressionSyntax(SyntaxToken openParenthesizedToken, ExpressionSyntax expression,
            SyntaxToken closedParenthesizedToken)
        {
            OpenParenthesizedToken = openParenthesizedToken;
            Expression = expression;
            ClosedParenthesizedToken = closedParenthesizedToken;
        }

        public override SyntaxKind Kind => SyntaxKind.ParenthesizedExpression;

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            yield return OpenParenthesizedToken;
            yield return Expression;
            yield return ClosedParenthesizedToken;
        }
    }
}