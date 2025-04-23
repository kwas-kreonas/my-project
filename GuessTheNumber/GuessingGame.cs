using System;

public class GuessingGame
{
    private readonly int targetNumber;
    public int Attempts { get; private set; }

    public GuessingGame(int? fixedNumber = null)
    {
        targetNumber = fixedNumber ?? new Random().Next(1, 101);
        Attempts = 0;
    }

    public string MakeGuess(int guess)
    {
        Attempts++;

        if (guess < targetNumber)
            return "Загадане число більше.";
        if (guess > targetNumber)
            return "Загадане число менше.";
        return $"Вітаємо! Ви вгадали число {targetNumber} за {Attempts} спроб.";
    }
}
