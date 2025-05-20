using neetcode.ArraysAndHashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.ArraysAndHashing;
public class EncodingAndDecodingTests
{
    [Fact]
    public void EncodeDecode_RoundTrips_SimpleStrings()
    {
        var input = new List<string> { "hello", "cat" };
        var encoded = EncodingAndDecoding.Encode(input);
        var decoded = EncodingAndDecoding.Decode(encoded);

        Assert.Equal(input, decoded);
    }

    [Fact]
    public void EncodeDecode_RoundTrips_EmptyList()
    {
        var input = new List<string>();
        var encoded = EncodingAndDecoding.Encode(input);
        var decoded = EncodingAndDecoding.Decode(encoded);

        Assert.Equal(input, decoded);
        Assert.Equal(string.Empty, encoded);
    }

    [Fact]
    public void EncodeDecode_RoundTrips_EmptyStrings()
    {
        var input = new List<string> { "", "", "" };
        var encoded = EncodingAndDecoding.Encode(input);
        var decoded = EncodingAndDecoding.Decode(encoded);

        Assert.Equal(input, decoded);
    }

    [Fact]
    public void EncodeDecode_RoundTrips_SpecialCharacters()
    {
        var input = new List<string> { "abc123", "x|y|z", "42|42|42" };
        var encoded = EncodingAndDecoding.Encode(input);
        var decoded = EncodingAndDecoding.Decode(encoded);

        Assert.Equal(input, decoded);
    }

    [Fact]
    public void Decode_HandlesSingleEncodedString()
    {
        string encoded = "4|test";
        var expected = new List<string> { "test" };
        var result = EncodingAndDecoding.Decode(encoded);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Encode_ProducesExpectedFormat()
    {
        var input = new List<string> { "a", "bb", "ccc" };
        var encoded = EncodingAndDecoding.Encode(input);

        Assert.Equal("1|a2|bb3|ccc", encoded);
    }
}