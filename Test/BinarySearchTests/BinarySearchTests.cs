using neetcode.BinarySearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.BinarySearchTests;

public class BinarySearchTests
{
    [Fact]
    public void FindsElementInMiddle()
    {
        int[] nums = { 1, 3, 5, 7, 9 };
        Assert.Equal(2, BinarySearch.BinarySearchRec(nums, 5));
        Assert.Equal(2, BinarySearch.BinarySearchIt(nums, 5));
    }

    [Fact]
    public void FindsElementAtStart()
    {
        int[] nums = { 1, 3, 5, 7, 9 };
        Assert.Equal(0, BinarySearch.BinarySearchRec(nums, 1));
        Assert.Equal(0, BinarySearch.BinarySearchIt(nums, 1));
    }

    [Fact]
    public void FindsElementAtEnd()
    {
        int[] nums = { 1, 3, 5, 7, 9 };
        Assert.Equal(4, BinarySearch.BinarySearchRec(nums, 9));
        Assert.Equal(4, BinarySearch.BinarySearchIt(nums, 9));
    }

    [Fact]
    public void ReturnsMinusOneIfNotFound()
    {
        int[] nums = { 1, 3, 5, 7, 9 };
        Assert.Equal(-1, BinarySearch.BinarySearchRec(nums, 6));
        Assert.Equal(-1, BinarySearch.BinarySearchIt(nums, 6));
    }

    [Fact]
    public void WorksOnEmptyArray()
    {
        int[] nums = { };
        Assert.Equal(-1, BinarySearch.BinarySearchRec(nums, 1));
        Assert.Equal(-1, BinarySearch.BinarySearchIt(nums, 1));
    }

    [Fact]
    public void WorksOnSingleElementArray_Found()
    {
        int[] nums = { 42 };
        Assert.Equal(0, BinarySearch.BinarySearchRec(nums, 42));
        Assert.Equal(0, BinarySearch.BinarySearchIt(nums, 42));
    }

    [Fact]
    public void WorksOnSingleElementArray_NotFound()
    {
        int[] nums = { 42 };
        Assert.Equal(-1, BinarySearch.BinarySearchRec(nums, 7));
        Assert.Equal(-1, BinarySearch.BinarySearchIt(nums, 7));
    }

    [Fact]
    public void WorksWithNegativeNumbers()
    {
        int[] nums = { -10, -5, 0, 5, 10 };
        Assert.Equal(1, BinarySearch.BinarySearchRec(nums, -5));
        Assert.Equal(1, BinarySearch.BinarySearchIt(nums, -5));
    }

    [Fact]
    public void WorksWithEvenNumberOfElements()
    {
        int[] nums = { 2, 4, 6, 8 };
        Assert.Equal(2, BinarySearch.BinarySearchRec(nums, 6));
        Assert.Equal(2, BinarySearch.BinarySearchIt(nums, 6));
    }

    [Fact]
    public void ReturnsMinusOneForTargetLessThanMin()
    {
        int[] nums = { 10, 20, 30 };
        Assert.Equal(-1, BinarySearch.BinarySearchRec(nums, 5));
        Assert.Equal(-1, BinarySearch.BinarySearchIt(nums, 5));
    }

    [Fact]
    public void ReturnsMinusOneForTargetGreaterThanMax()
    {
        int[] nums = { 10, 20, 30 };
        Assert.Equal(-1, BinarySearch.BinarySearchRec(nums, 40));
        Assert.Equal(-1, BinarySearch.BinarySearchIt(nums, 40));
    }
}