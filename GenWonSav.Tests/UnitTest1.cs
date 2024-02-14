namespace GenWonSav.Tests;
using NUnit;


[TestFixture]
public class Tests
{
    const string fileName = "data.sav";
    private GameData gameData;

    byte[] left = {0x00, 0x01, 0x02};
    byte[] right = {0x00, 0x01, 0x02};
    byte[] middle = { 0x00, 0x00, 0x00};
    byte[] longer = { 0x00, 0x01, 0x02, 0x03};

    [SetUp]
    public void Setup()
    {
        gameData = new GameData(fileName);
    }

    [Test]
    public void differentLengthNotSame()
    {

        Assert.False(HexFunctions.compareData(left, longer));
    }

    [Test]
    public void sameLengthDifferentAreDifferent()
    {
        Assert.False(HexFunctions.compareData(left, middle));
    }

    [Test]
    public void sameAreSame()
    {
        Assert.True(HexFunctions.compareData(left, right));
    }
}