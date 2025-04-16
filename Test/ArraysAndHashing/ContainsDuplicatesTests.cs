using neetcode.ArraysAndHashing;

namespace Test.ArraysAndHashing;

public class ContainsDuplicatesTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, false)]  // No duplicates
    [InlineData(new int[] { 1, 2, 3, 3 }, true)]   // Contains duplicates
    [InlineData(new int[] { }, false)]            // Empty array
    [InlineData(new int[] { 1, 1, 1, 1 }, true)]  // All duplicates
    [InlineData(new int[] { 1 }, false)]          // Single element
    public void HasDuplicates1_ReturnsExpectedResult(int[] nums, bool expected)
    {
        // Act
        var result = ContainsDuplicates.HasDuplicates1(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, false)]  // No duplicates
    [InlineData(new int[] { 1, 2, 3, 3 }, true)]   // Contains duplicates
    [InlineData(new int[] { }, false)]            // Empty array
    [InlineData(new int[] { 1, 1, 1, 1 }, true)]  // All duplicates
    [InlineData(new int[] { 1 }, false)]          // Single element
    public void HasDuplicates2_ReturnsExpectedResult(int[] nums, bool expected)
    {
        // Act
        var result = ContainsDuplicates.HasDuplicates2(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, false)]  // No duplicates
    [InlineData(new int[] { 1, 2, 3, 3 }, true)]   // Contains duplicates
    [InlineData(new int[] { }, false)]            // Empty array
    [InlineData(new int[] { 1, 1, 1, 1 }, true)]  // All duplicates
    [InlineData(new int[] { 1 }, false)]          // Single element
    public void HasDuplicates3_ReturnsExpectedResult(int[] nums, bool expected)
    {
        // Act
        var result = ContainsDuplicates.HasDuplicates3(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, false)]  // No duplicates
    [InlineData(new int[] { 1, 2, 3, 3 }, true)]   // Contains duplicates
    [InlineData(new int[] { }, false)]            // Empty array
    [InlineData(new int[] { 1, 1, 1, 1 }, true)]  // All duplicates
    [InlineData(new int[] { 1 }, false)]          // Single element
    public void HasDuplicates4_ReturnsExpectedResult(int[] nums, bool expected)
    {
        // Act
        var result = ContainsDuplicates.HasDuplicates3(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}