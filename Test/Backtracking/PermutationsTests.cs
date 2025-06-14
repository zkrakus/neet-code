using neetcode.Backtracking;

namespace Test.Backtracking;
public class PermutationsTests
{

    [Fact]
    public void Permute_EmptyArray_ReturnsEmptyList()
    {
        var result = Permutations.Permute(new int[] { });
        Assert.Empty(result);
    }

    [Fact]
    public void Permute_SingleElement_ReturnsSinglePermutation()
    {
        var result = Permutations.Permute(new int[] { 1 });
        Assert.Single(result);
        Assert.Equal(new List<int> { 1 }, result[0]);
    }

    [Fact]
    public void Permute_TwoElements_ReturnsTwoPermutations()
    {
        var result = Permutations.Permute(new int[] { 1, 2 });
        Assert.Equal(2, result.Count);
        Assert.Contains(result, r => r.SequenceEqual(new List<int> { 1, 2 }));
        Assert.Contains(result, r => r.SequenceEqual(new List<int> { 2, 1 }));
    }

    [Fact]
    public void Permute_ThreeElements_ReturnsSixPermutations()
    {
        var expected = new List<List<int>>
        {
            new() { 1, 2, 3 },
            new() { 1, 3, 2 },
            new() { 2, 1, 3 },
            new() { 2, 3, 1 },
            new() { 3, 1, 2 },
            new() { 3, 2, 1 }
        };

        var result = Permutations.Permute(new int[] { 1, 2, 3 });
        Assert.Equal(6, result.Count);

        foreach (var perm in expected)
            Assert.Contains(result, r => r.SequenceEqual(perm));
    }
}
