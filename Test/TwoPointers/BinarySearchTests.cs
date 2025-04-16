using neetcode.TwoPointers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.TwoPointers;

public class BinarySearchTests
{
    [Fact]
    public void FindsElementInMiddle()
    {
        int[] nums = { 1, 3, 5, 7, 9 };
        Assert.Equal(2, BinarySearch.Search(nums, 5));
    }

    [Fact]
    public void FindsElementAtStart()
    {
        int[] nums = { 1, 3, 5, 7, 9 };
        Assert.Equal(0, BinarySearch.Search(nums, 1));
    }

    [Fact]
    public void FindsElementAtEnd()
    {
        int[] nums = { 1, 3, 5, 7, 9 };
        Assert.Equal(4, BinarySearch.Search(nums, 9));
    }

    [Fact]
    public void ReturnsMinusOneIfNotFound()
    {
        int[] nums = { 1, 3, 5, 7, 9 };
        Assert.Equal(-1, BinarySearch.Search(nums, 6));
    }

    [Fact]
    public void WorksOnEmptyArray()
    {
        int[] nums = { };
        Assert.Equal(-1, BinarySearch.Search(nums, 1));
    }

    [Fact]
    public void WorksOnSingleElementArray_Found()
    {
        int[] nums = { 42 };
        Assert.Equal(0, BinarySearch.Search(nums, 42));
    }

    [Fact]
    public void WorksOnSingleElementArray_NotFound()
    {
        int[] nums = { 42 };
        Assert.Equal(-1, BinarySearch.Search(nums, 7));
    }

    [Fact]
    public void WorksWithNegativeNumbers()
    {
        int[] nums = { -10, -5, 0, 5, 10 };
        Assert.Equal(1, BinarySearch.Search(nums, -5));
    }

    [Fact]
    public void WorksWithEvenNumberOfElements()
    {
        int[] nums = { 2, 4, 6, 8 };
        Assert.Equal(2, BinarySearch.Search(nums, 6));
    }

    [Fact]
    public void ReturnsMinusOneForTargetLessThanMin()
    {
        int[] nums = { 10, 20, 30 };
        Assert.Equal(-1, BinarySearch.Search(nums, 5));
    }

    [Fact]
    public void ReturnsMinusOneForTargetGreaterThanMax()
    {
        int[] nums = { 10, 20, 30 };
        Assert.Equal(-1, BinarySearch.Search(nums, 40));
    }

}
