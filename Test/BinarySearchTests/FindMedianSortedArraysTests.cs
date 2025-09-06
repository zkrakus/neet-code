using neetcode.BinarySearch;

namespace Test.BinarySearchTests;
public class FindMedianSortedArraysTests
{
    public static IEnumerable<object[]> Cases()
    {
        // Odd total length
        yield return new object[] { new[] { 1, 3 }, new[] { 2 }, 2.0 };
        yield return new object[] { Array.Empty<int>(), new[] { 1, 2, 3 }, 2.0 };
        yield return new object[] { new[] { -3, -1 }, new[] { -2 }, -2.0 };
        yield return new object[] { new[] { 1 }, new[] { 2, 3 }, 2.0 };

        // Even total length
        yield return new object[] { new[] { 1, 2 }, new[] { 3, 4 }, 2.5 };
        yield return new object[] { Array.Empty<int>(), new[] { 1, 2 }, 1.5 };
        yield return new object[] { new[] { 0, 0 }, new[] { 0, 0 }, 0.0 };
        yield return new object[] { new[] { 1 }, new[] { 2 }, 1.5 };
        yield return new object[] { new[] { 1, 2, 2 }, new[] { 2, 2, 3 }, 2.0 };

        // Unequal sizes
        yield return new object[] { new[] { 1, 4, 7, 10, 12 }, new[] { 2, 3 }, 4.0 }; // merged: [1,2,3,4,7,10,12]
        yield return new object[] { new[] { 2 }, new[] { 1, 3, 4, 5, 6 }, 3.5 };

        // Empty vs non-empty
        yield return new object[] { Array.Empty<int>(), new[] { 1 }, 1.0 };
        yield return new object[] { new[] { -5, -3, -1 }, Array.Empty<int>(), -3.0 };

        // Duplicates / plateaus
        yield return new object[] { new[] { 1, 1, 1 }, new[] { 1, 1 }, 1.0 };

        // Boundaries
        yield return new object[] { new[] { int.MinValue }, new[] { int.MaxValue }, -0.5 };
        yield return new object[] { new[] { int.MinValue, 0 }, new[] { int.MaxValue }, 0.0 };
    }

    [Theory]
    [MemberData(nameof(Cases))]
    //[InlineData(new[] { 1, 3 }, new[] { 2,4,5,6 }, 3.5)]
    public void Find_ReturnsExpected_MemberData(int[] a, int[] b, double expected)
    {
        var result = FindMedianSortedArrays.Find(a, b);
        Assert.Equal(expected, result, 10);

        // Symmetry: swapping arrays must not change the result
        var resultSwapped = FindMedianSortedArrays.Find(b, a);
        Assert.Equal(expected, resultSwapped, 10);
    }

    public static IEnumerable<object[]> ReferenceCheckCases()
    {
        yield return new object[] { new[] { -5, -3, -1 }, new[] { -4, -2, 0, 1 } };
        yield return new object[] { new[] { 1, 1, 1 }, new[] { 1, 1 } };
        yield return new object[] { new[] { 1, 4, 7, 10, 12 }, new[] { 2, 3 } };
        yield return new object[] { new[] { 2 }, new[] { 1, 3, 4, 5, 6 } };
        yield return new object[] { Array.Empty<int>(), new[] { 5 } };
        yield return new object[] { new[] { 0, 0, 0 }, new[] { 0, 0 } };
    }

    [Theory]
    [MemberData(nameof(ReferenceCheckCases))]
    public void Find_MatchesReferenceMergeMedian(int[] a, int[] b)
    {
        var expected = ReferenceMedian(a, b);
        var actual = FindMedianSortedArrays.Find(a, b);
        Assert.Equal(expected, actual, 10);

        // Symmetry check
        var actualSwapped = FindMedianSortedArrays.Find(b, a);
        Assert.Equal(expected, actualSwapped, 10);
    }

    private static double ReferenceMedian(int[] a, int[] b)
    {
        var merged = new List<int>(a.Length + b.Length);
        merged.AddRange(a);
        merged.AddRange(b);
        merged.Sort();

        int n = merged.Count;
        if (n == 0) return -1; // Your implementation returns -1 for impossible inputs

        if ((n & 1) == 1)
            return merged[n / 2];

        return (merged[n / 2 - 1] + merged[n / 2]) / 2.0;
    }
}