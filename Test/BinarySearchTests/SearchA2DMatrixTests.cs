using neetcode.BinarySearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.BinarySearchTests;
public class SearchA2DMatrixTests
{
    [Fact]
    public void SearchMatrix_TargetExistsInMiddleRow()
    {
        int[][] matrix = new[]
        {
            new[] { 1, 3, 5 },
            new[] { 7, 9, 11 },
            new[] { 13, 15, 17 }
        };

        bool result = SearchA2DMatrix.SearchMatrix(matrix, 9);
        Assert.True(result);
    }

    [Fact]
    public void SearchMatrix_TargetIsFirstElement()
    {
        int[][] matrix = new[]
        {
            new[] { 1, 2, 3 },
            new[] { 4, 5, 6 }
        };

        bool result = SearchA2DMatrix.SearchMatrix(matrix, 1);
        Assert.True(result);
    }

    [Fact]
    public void SearchMatrix_TargetIsLastElement()
    {
        int[][] matrix = new[]
        {
            new[] { 10, 20 },
            new[] { 30, 40 },
            new[] { 50, 60 }
        };

        bool result = SearchA2DMatrix.SearchMatrix(matrix, 60);
        Assert.True(result);
    }

    [Fact]
    public void SearchMatrix_TargetDoesNotExist()
    {
        int[][] matrix = new[]
        {
            new[] { 1, 2, 3 },
            new[] { 5, 6, 7 },
            new[] { 8, 9, 10 }
        };

        bool result = SearchA2DMatrix.SearchMatrix(matrix, 4);
        Assert.False(result);
    }

    [Fact]
    public void SearchMatrix_EmptyMatrix()
    {
        int[][] matrix = new int[0][];
        bool result = SearchA2DMatrix.SearchMatrix(matrix, 5);
        Assert.False(result);
    }

    [Fact]
    public void SearchMatrix_SingleRow()
    {
        int[][] matrix = new[]
        {
            new[] { 2, 4, 6, 8 }
        };

        bool result = SearchA2DMatrix.SearchMatrix(matrix, 6);
        Assert.True(result);
    }

    [Fact]
    public void SearchMatrix_SingleColumn()
    {
        int[][] matrix = new[]
        {
            new[] { 1 },
            new[] { 3 },
            new[] { 5 },
            new[] { 7 }
        };

        bool result = SearchA2DMatrix.SearchMatrix(matrix, 5);
        Assert.True(result);
    }
}
