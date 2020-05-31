namespace Octo
{
    internal enum SyntaxKind
    {
        BadToken,
        EndOfFileToken,
        CloseParenthesisToken,
        OpenParenthesisToken,
        SlashToken,
        StarToken,
        MinusToken,
        PlusToken,
        WhiteSpaceToken,
        NumberToken,
        LiteralExpression,
        BinaryExpression,
        ParenthesizedExpression
    }
}