using neetcode.Stack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Stack;
public class ValidParenthesesTests
{
    [Fact]
    public void MixedValid_ReturnsTrue()
    {
        Assert.True(ValidParentheses.IsValid("([]){}"));
    }

    [Fact]
    public void NestedMixedValid_ReturnsTrue()
    {
        Assert.True(ValidParentheses.IsValid("{[()()]}"));
    }

    [Fact]
    public void UnmatchedLeftOnly_ReturnsFalse()
    {
        Assert.False(ValidParentheses.IsValid("((("));
    }

    [Fact]
    public void UnmatchedRightOnly_ReturnsFalse()
    {
        Assert.False(ValidParentheses.IsValid(")))"));
    }

    [Fact]
    public void MisorderedBrackets_ReturnsFalse()
    {
        Assert.False(ValidParentheses.IsValid("([)]"));
    }

    [Fact]
    public void MismatchedClosing_ReturnsFalse()
    {
        Assert.False(ValidParentheses.IsValid("{(})"));
    }

    [Fact]
    public void SingleBracket_ReturnsFalse()
    {
        Assert.False(ValidParentheses.IsValid("["));
    }

    [Fact]
    public void CorrectlyBalancedAndNested_ReturnsTrue()
    {
        Assert.True(ValidParentheses.IsValid("{[()]}"));
    }

    [Fact]
    public void EmptyString_ReturnsTrue()
    {
        Assert.True(ValidParentheses.IsValid(""));
    }
}