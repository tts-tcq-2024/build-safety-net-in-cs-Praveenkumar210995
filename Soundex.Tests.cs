using System.Globalization;
using System.Xml.Linq;
using Xunit;
using System.Collections.Generic;
using System;
using code_test_cover;

public class SoundexTests
{
    [Fact]
    public void HandleEmptyString()
    {
        Assert.Equal("", Soundex.GenerateSoundex(""));
    }

    [Fact]
    public void HandleSingleString()
    {
        Assert.Equal("A000", Soundex.GenerateSoundex("A"));
    }

    [Fact]
    public void HandleString()
    {
        Assert.Equal("R163", Soundex.GenerateSoundex("Robert"));
    }

    [Fact]
    public void HandleStringLowercase()
    {
        Assert.Equal("A120", Soundex.GenerateSoundex("aaBJE1"));
    }

    [Fact]
    public void HandleStringVowelSeperate()
    {
        Assert.Equal("T522", Soundex.GenerateSoundex("Tymczak"));
    }

    [Fact]
    public void HandleStringInitialSamecode()
    {
        Assert.Equal("P236", Soundex.GenerateSoundex("Pfister"));
    }
        [Fact]
    public void HandleStringOtherSeperator()
    {
        Assert.Equal("H525", Soundex.GenerateSoundex("Honeycomb"));
    }
 }
