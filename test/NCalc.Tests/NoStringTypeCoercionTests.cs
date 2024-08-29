namespace NCalc.Tests;

[Trait("Category", "NoTypeCoercion")]
public class NoStringTypeCoercionTests
{
    [Theory]
    [InlineData("'to' + 'to'", "toto")]
    [InlineData("'one' + 2", "one2")]
    [InlineData("'one' + 2.1", "one2.1")]
    [InlineData("2 + 'one'", "2one")]
    [InlineData("2.1 + 'one'", "2.1one")]
    [InlineData("'1' + '2'", "12")]
    [InlineData("'1.1' + '2'", "1.12")]
    [InlineData("'1' + '2.2'", "12.2")]
    [InlineData("1 + 2", 3)]
    [InlineData("1.5 + 2.5", 4.0)]
    [InlineData("'10' + 'mA - ' + (10 + 20) + 'mA'", "10mA - 30mA")]
    public void ShouldUseStringConcatenationIfEitherValueIsAString(string expression, object expected)
    {
        Assert.Equal(expected, new Expression(expression, ExpressionOptions.NoStringTypeCoercion).Evaluate());
    }
}