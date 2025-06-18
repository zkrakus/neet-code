using neetcode.HeapAndPriorityQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.HeapAndPriorityQueue;
public class KClosestPointsToOriginTests
{
    [Fact]
    public void KClosest_ReturnsEmptyArray_WhenKIsZero()
    {
        int[][] points = new int[][]
        {
                new int[] { 1, 2 },
                new int[] { 3, 4 }
        };

        var result = KClosestPointsToOrigin.KClosest(points, 0);

        Assert.Empty(result);
    }

    [Fact]
    public void KClosest_ReturnsAllPoints_WhenKEqualsPointsCount()
    {
        int[][] points = new int[][]
        {
                new int[] { 1, 2 },
                new int[] { 3, 4 }
        };

        var result = KClosestPointsToOrigin.KClosest(points, 2);

        Assert.Equal(2, result.Length);
        Assert.Contains(result, p => p[0] == 1 && p[1] == 2);
        Assert.Contains(result, p => p[0] == 3 && p[1] == 4);
    }

    [Fact]
    public void KClosest_ReturnsSingleClosestPoint()
    {
        int[][] points = new int[][]
        {
                new int[] { 5, 5 },
                new int[] { 2, 1 },
                new int[] { -1, -1 }
        };

        var result = KClosestPointsToOrigin.KClosest(points, 1);

        Assert.Single(result);
        Assert.True(result[0][0] == -1 && result[0][1] == -1 || result[0][0] == 2 && result[0][1] == 1);
    }

    [Fact]
    public void KClosest_ReturnsKClosestPoints_RegardlessOfOrder()
    {
        int[][] points = new int[][]
        {
                new int[] { 1, 3 },
                new int[] { -2, 2 },
                new int[] { 5, 8 },
                new int[] { 0, 1 }
        };

        var result = KClosestPointsToOrigin.KClosest(points, 2);

        Assert.Equal(2, result.Length);
        Assert.Contains(result, p => p[0] == -2 && p[1] == 2);
        Assert.Contains(result, p => p[0] == 0 && p[1] == 1);
    }

    [Fact]
    public void KClosest_ReturnsCorrectly_WhenAllPointsSameDistance()
    {
        int[][] points = new int[][]
        {
                new int[] { 1, 1 },
                new int[] { -1, -1 },
                new int[] { 1, -1 },
                new int[] { -1, 1 }
        };

        var result = KClosestPointsToOrigin.KClosest(points, 2);

        Assert.Equal(2, result.Length);
    }
}
