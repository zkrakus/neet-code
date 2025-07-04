using neetcode.Intervals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Intervals;

public class InsertIntervalTests
{
    [Fact]
    public void Insert_EmptyIntervals_ReturnsNewIntervalOnly()
    {
        // Arrange
        var intervals = new int[][] { };
        var newInterval = new int[] { 5, 7 };

        // Act
        var result = InsertInterval.Insert(intervals, newInterval);

        // Assert
        Assert.Single(result);
        Assert.Equal(new[] { 5, 7 }, result[0]);
    }

    [Fact]
    public void Insert_NoOverlap_AddAtBeginning()
    {
        var intervals = new[] { new[] { 10, 12 }, new[] { 15, 18 } };
        var newInterval = new[] { 1, 5 };

        var result = InsertInterval.Insert(intervals, newInterval);

        Assert.Equal(3, result.Length);
        Assert.Equal(new[] { 1, 5 }, result[0]);
        Assert.Equal(new[] { 10, 12 }, result[1]);
        Assert.Equal(new[] { 15, 18 }, result[2]);
    }

    [Fact]
    public void Insert_NoOverlap_AddAtEnd()
    {
        var intervals = new[] { new[] { 1, 2 }, new[] { 3, 5 } };
        var newInterval = new[] { 10, 12 };

        var result = InsertInterval.Insert(intervals, newInterval);

        Assert.Equal(3, result.Length);
        Assert.Equal(new[] { 1, 2 }, result[0]);
        Assert.Equal(new[] { 3, 5 }, result[1]);
        Assert.Equal(new[] { 10, 12 }, result[2]);
    }

    [Fact]
    public void Insert_OverlapSingleInterval_MergesCorrectly()
    {
        var intervals = new[] { new[] { 1, 3 }, new[] { 6, 9 } };
        var newInterval = new[] { 2, 5 };

        var result = InsertInterval.Insert(intervals, newInterval);

        Assert.Equal(2, result.Length);
        Assert.Equal(new[] { 1, 5 }, result[0]);
        Assert.Equal(new[] { 6, 9 }, result[1]);
    }

    [Fact]
    public void Insert_OverlapMultipleIntervals_MergesAll()
    {
        var intervals = new[] {
            new[] { 1, 2 },
            new[] { 3, 5 },
            new[] { 6, 7 },
            new[] { 8, 10 },
            new[] { 12, 16 }
        };

        var newInterval = new[] { 4, 9 };

        var result = InsertInterval.Insert(intervals, newInterval);

        Assert.Equal(3, result.Length);
        Assert.Equal(new[] { 1, 2 }, result[0]);
        Assert.Equal(new[] { 3, 10 }, result[1]);
        Assert.Equal(new[] { 12, 16 }, result[2]);
    }

    [Fact]
    public void Insert_ExactOverlap_ReplacesWithNewMerged()
    {
        var intervals = new[] {
            new[] { 1, 5 },
            new[] { 6, 9 }
        };

        var newInterval = new[] { 1, 9 };

        var result = InsertInterval.Insert(intervals, newInterval);

        Assert.Single(result);
        Assert.Equal(new[] { 1, 9 }, result[0]);
    }

    [Fact]
    public void Insert_ContainedWithinExisting_DoesNotChange()
    {
        var intervals = new[] {
            new[] { 1, 5 },
            new[] { 10, 15 }
        };

        var newInterval = new[] { 11, 12 };

        var result = InsertInterval.Insert(intervals, newInterval);

        Assert.Equal(2, result.Length);
        Assert.Equal(new[] { 1, 5 }, result[0]);
        Assert.Equal(new[] { 10, 15 }, result[1]); // will be merged since there's overlap
    }
}