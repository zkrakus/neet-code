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
        var result = ThreeSum.Sum2(null);
        Assert.Empty(result);
    }

    [Fact]
    public void ReturnsEmptyList_WhenInputHasLessThanThreeElements()
    {
        Assert.Empty(ThreeSum.Sum2(new int[] { 1 }));
        Assert.Empty(ThreeSum.Sum2(new int[] { 1, 2 }));
    }

    [Fact]
    public void ReturnsCorrectTriplets_ForSampleInput1()
    {
        var result = ThreeSum.Sum2(new int[] { -1, 0, 1, 2, -1, -4 });

        var expected = new List<List<int>>
        {
            new() { -1, -1, 2 },
            new() { -1, 0, 1 }
        };

        Assert.Equal(expected.Count, result.Count);
        foreach (var triplet in expected)
        {
            Assert.Contains(result, r => r.OrderBy(x => x).SequenceEqual(triplet.OrderBy(x => x)));
        }
    }

    [Fact]
    public void ReturnsEmptyList_WhenNoTripletsSumToZero()
    {
        var result = ThreeSum.Sum2(new int[] { 0, 1, 1 });
        Assert.Empty(result);
    }

    [Fact]
    public void ReturnsEmptyList_WhenTripletSumNotZero()
    {
        var result = ThreeSum.Sum2(new int[] { 3, -2, 1, 0 });
        Assert.Empty(result);
    }

    [Fact]
    public void HandlesAllZeros()
    {
        var result = ThreeSum.Sum2(new int[] { 0, 0, 0 });

        var expected = new List<int> { 0, 0, 0 };
        Assert.Single(result);
        Assert.True(result[0].OrderBy(x => x).SequenceEqual(expected));
    }

    [Fact]
    public void ReturnsCorrectTriplet_ForValidSimpleInput()
    {
        var result = ThreeSum.Sum2(new int[] { 1, 2, -3 });

        var expected = new List<int> { -3, 1, 2 };
        Assert.Single(result);
        Assert.True(result[0].OrderBy(x => x).SequenceEqual(expected));
    }
}

