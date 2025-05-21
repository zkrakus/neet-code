using neetcode.Stack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Stack;
public class EvaluateReversePolishNotationTests
{
    [Fact]
    public void EvalRPN_Addition_ReturnsCorrectResult()
    {
        var tokens = new[] { "2", "3", "+" };
        int result = EvaluateReversePolishNotation.EvalRPN(tokens);
        Assert.Equal(5, result);
    }

    [Fact]
    public void EvalRPN_Subtraction_ReturnsCorrectResult()
    {
        var tokens = new[] { "10", "4", "-" };
        int result = EvaluateReversePolishNotation.EvalRPN(tokens);
        Assert.Equal(6, result);
    }

    [Fact]
    public void EvalRPN_Multiplication_ReturnsCorrectResult()
    {
        var tokens = new[] { "2", "3", "*" };
        int result = EvaluateReversePolishNotation.EvalRPN(tokens);
        Assert.Equal(6, result);
    }

    [Fact]
    public void EvalRPN_Division_ReturnsCorrectResult()
    {
        var tokens = new[] { "8", "2", "/" };
        int result = EvaluateReversePolishNotation.EvalRPN(tokens);
        Assert.Equal(4, result);
    }

    [Fact]
    public void EvalRPN_MixedExpression_ReturnsCorrectResult()
    {
        var tokens = new[] { "2", "1", "+", "3", "*" }; // (2 + 1) * 3 = 9
        int result = EvaluateReversePolishNotation.EvalRPN(tokens);
        Assert.Equal(9, result);
    }

    [Fact]
    public void EvalRPN_ComplexExpression_ReturnsCorrectResult()
    {
        var tokens = new[] { "4", "13", "5", "/", "+" }; // 4 + (13 / 5) = 6
        int result = EvaluateReversePolishNotation.EvalRPN(tokens);
        Assert.Equal(6, result);
    }

    [Fact]
    public void EvalRPN_SingleValue_ReturnsThatValue()
    {
        var tokens = new[] { "42" };
        int result = EvaluateReversePolishNotation.EvalRPN(tokens);
        Assert.Equal(42, result);
    }
}
