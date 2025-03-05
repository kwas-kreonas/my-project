using Xunit;

public class GuessingGameTests
{
    [Fact]
    public void MakeGuess_GuessLowerThanTarget_ReturnsHint()
    {
        var game = new GuessingGame(50);
        string result = game.MakeGuess(30);
        Assert.Equal("Загадане число більше.", result);
    }

    [Fact]
    public void MakeGuess_GuessHigherThanTarget_ReturnsHint()
    {
        var game = new GuessingGame(50);
        string result = game.MakeGuess(70);
        Assert.Equal("Загадане число менше.", result);
    }

    [Fact]
    public void MakeGuess_CorrectGuess_ReturnsWinMessage()
    {
        var game = new GuessingGame(50);
        string result = game.MakeGuess(50);
        Assert.Contains("Вітаємо!", result);
    }

    [Fact]
    public void MakeGuess_CountsAttemptsCorrectly()
    {
        var game = new GuessingGame(50);
        game.MakeGuess(10);
        game.MakeGuess(20);
        game.MakeGuess(50);
        Assert.Equal(3, game.Attempts);
    }
}
