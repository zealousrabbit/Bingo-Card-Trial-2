using System;
using System.Collections.Generic;

class BingoCardGenerator
{
    static void Main()
    {
        // Get user input for card size
        Console.Write("Enter the size of the bingo card (e.g., 5 for a 5x5 card): ");
        if (!int.TryParse(Console.ReadLine(), out int size) || size < 1)
        {
            Console.WriteLine("Invalid size. Please enter a positive integer.");
            return;
        }

        // Get the number of phrases required
        int numberOfPhrases = size * size;
        List<string> phrases = new List<string>();

        Console.WriteLine($"Enter {numberOfPhrases} phrases:");

        for (int i = 0; i < numberOfPhrases; i++)
        {
            Console.Write($"Phrase {i + 1}: ");
            phrases.Add(Console.ReadLine());
        }

        // Shuffle the phrases
        Shuffle(phrases);

        // Generate and display the bingo card
        DisplayBingoCard(phrases, size);
    }

    static void Shuffle<T>(List<T> list)
    {
        Random rng = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    static void DisplayBingoCard(List<string> phrases, int size)
    {
        Console.WriteLine("\nYour Bingo Card:");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                string phrase = phrases[i * size + j];
                Console.Write($"{phrase,-20} ");
            }
            Console.WriteLine();
        }
    }
}