using System;

class Program
{
    static void Main()
    {
        GuessingGame game = new GuessingGame();
        int guess = 0;

        Console.WriteLine("Гра 'Вгадай число'! Спробуйте вгадати число від 1 до 100.");

        while (true)
        {
            Console.Write("Введіть число: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out guess))
            {
                string result = game.MakeGuess(guess);
                Console.WriteLine(result);
                if (result.StartsWith("Вітаємо")) break;
            }
            else
            {
                Console.WriteLine("Будь ласка, введіть коректне число.");
            }
        }
    }
}
