using neetcode.BinarySearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.BinarySearchTests;

public class KokoEatingBananasTests
{
    [Theory]
    [InlineData(new[] { 3, 6, 7, 11 }, 8, 4)]
    [InlineData(new[] { 30, 11, 23, 4, 20 }, 5, 30)]
    [InlineData(new[] { 30, 11, 23, 4, 20 }, 6, 23)]
    [InlineData(new[] { 1, 1, 1, 1 }, 4, 1)]
    [InlineData(new[] { 1000000000 }, 2, 500000000)]
    [InlineData(new[] { 1 }, 1, 1)]
    [InlineData(new[] { 312884470 }, 968709470, 1)]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 9, 9)]
    public void MinEatingSpeed_ReturnsExpected(int[] piles, int h, int expected)
    {
        int actual = KokoEatingBananas.MinEatingSpeed(piles, h);
        Assert.Equal(expected, actual);
    }
}
