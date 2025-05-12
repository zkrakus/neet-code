using neetcode.TwoPointers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.TwoPointers;

public class ThreeSumTests
{
    [Fact]
    public void ReturnsEmptyList_WhenInputIsNull()
    {
        var result = ThreeSum.Sum(null);
        Assert.Empty(result);
    }

    [Fact]
    public void ReturnsEmptyList_WhenInputHasLessThanThreeElements()
    {
        var result = ThreeSum.Sum(new int[] { 1 });
        Assert.Empty(result);

        result = ThreeSum.Sum(new int[] { 1, 2 });
        Assert.Empty(result);
    }

    [Fact]
    public void ReturnsCorrectIndices_ForSampleInput1()
    {
        var result = ThreeSum.Sum(new int[] { -1, 0, 1, 2, -1, -4 });
        Assert.Contains(result, triplet => triplet.Count == 3);
    }

    [Fact]
    public void ReturnsEmptyList_WhenNoTripletsSumToZero()
    {
        var result = ThreeSum.Sum(new int[] { 0, 1, 1 });
        Assert.Empty(result);
    }

    [Fact]
    public void ReturnsEmptyList_WhenTripletSumNotZero()
    {
        var result = ThreeSum.Sum(new int[] { 3, -2, 1, 0 });
        Assert.Empty(result);
    }

    [Fact]
    public void HandlesAllZeros()
    {
        var result = ThreeSum.Sum(new int[] { 0, 0, 0 });
        Assert.Contains(result, triplet => triplet.Count == 3);
    }

    [Fact]
    public void ReturnsCorrectIndices_ForValidTriplet()
    {
        var result = ThreeSum.Sum(new int[] { 1, 2, -3 });
        Assert.Contains(new List<int> { 0, 1, 2 }, result);
    }
}

