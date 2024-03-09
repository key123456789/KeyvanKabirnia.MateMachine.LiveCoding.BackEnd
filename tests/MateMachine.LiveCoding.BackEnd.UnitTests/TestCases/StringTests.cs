using MateMachine.LiveCoding.BackEnd.Console.Services;

namespace MateMachine.LiveCoding.BackEnd.UnitTests.TestCases;

public class StringTests
{
    [Theory]
    [InlineData("Ali", false)]
    [InlineData("AlilA", true)]
    [InlineData("Aibohphobia", false)]
    [InlineData("AibohphobiA", true)]
    public void GivenSampleData_WhenCallingIsPalindrome_ThenExpectedShouldBeMet_WithLinq(string str, bool expectedResult)
    {
        var resultWithLinq = StringHelpers.IsPalindromeWithLinq(str);

        Assert.Equal(expectedResult, resultWithLinq);
    }

    [Theory]
    [InlineData("Ali", false)]
    [InlineData("AlilA", true)]
    [InlineData("Aibohphobia", false)]
    [InlineData("AibohphobiA", true)]
    public void GivenSampleData_WhenCallingIsPalindrome_ThenExpectedShouldBeMet_NoLinq(string str, bool expectedResult)
    {
        var resultNoLinq = StringHelpers.IsPalindromeNoLinq(str);

        Assert.Equal(expectedResult, resultNoLinq);
    }

    [Theory]
    [InlineData("Testing the word length", "the word length Testing")]
    [InlineData("Hello my name is Ali", "my is Ali name Hello")]
    public void GivenSampleData_WhenCallingSortByWordLength_ThenExpectedShouldBeReturned_WithLinq(
        string str, string expectedResult)
    {
        var resultWithLinq = StringHelpers.SortByWordLengthWithLinq(str);

        Assert.Equal(expectedResult, resultWithLinq);
    }

    [Theory]
    [InlineData("Testing the word length", "the word length Testing")]
    [InlineData("Hello my name is Ali", "my is Ali name Hello")]
    public void GivenSampleData_WhenCallingSortByWordLength_ThenExpectedShouldBeReturned_NoLinq(
        string str, string expectedResult)
    {
        var resultNoLinq = StringHelpers.SortByWordLengthNoLinq(str);

        Assert.Equal(expectedResult, resultNoLinq);
    }

    [Theory]
    [InlineData("aab", "xxy", true)]
    [InlineData("aab", "xyz", false)]
    [InlineData("Ali", "raw", true)]
    public void GivenSampleData_WhenCallingAreIsomorphic_ThenExpectedShouldBeReturned(
        string str1, string str2, bool expectedResult)
    {
        var result = StringHelpers.AreIsomorphic(str1, str2);

        Assert.Equal(expectedResult, result);
    }
}
