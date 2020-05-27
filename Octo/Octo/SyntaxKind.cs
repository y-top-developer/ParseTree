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
        NumberExpression,
        BinaryExpression,
        ParenthesizedExpression
    }
}