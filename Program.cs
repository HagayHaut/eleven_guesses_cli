using System;

namespace ElevenGuesses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********************************************************\n");
            Console.WriteLine("    WELCOME TO ELEVEN GUESSES!\n\n");
            Console.WriteLine("The game is simple:\n");
            Console.WriteLine("  1. I think of a secret number between 1 and 1000");
            Console.WriteLine("  2. You have 11 attempts to guess the secret number");
            Console.WriteLine("  3. I will tell you if the secret number is HIGHER or LOWER");

            Random random = new Random();
            int secret = random.Next(1000);
            int guessCount = 0;
            int currentGuess = 0;
            bool hasWon = false;

            // match -> 1
            // secret is HIGHER -> 2 
            // secret is LOWER -> 3
            // invalid -> 4
            int checkGuess(int guess)
            {
                if (guess < 0 || guess > 1000) return 4;
                if (guess > secret) return 3;
                if (guess < secret) return 2;
                return 1;
            }

            currentGuess++;

            while (guessCount < 11)
            {
                Console.WriteLine("\n");
                Console.Write(guessCount == 0 ? "Enter a guess to begin: " : "Enter your next guess: ");
                currentGuess = Int32.Parse(Console.ReadLine());

                while (checkGuess(currentGuess) == 4)
                {
                    Console.Write("\nPlease enter a number between 1 and 1000: ");
                    currentGuess = Int32.Parse(Console.ReadLine());
                }

                guessCount++;
                Console.WriteLine("\n  Current guess count is {0}\n", guessCount);

                if (checkGuess(currentGuess) == 1)
                {
                    hasWon = true;
                    Console.WriteLine("YOU WIN! The secret number is {0}\n\n", secret);
                    break;
                }

                if (checkGuess(currentGuess) == 2)
                {
                    Console.WriteLine("The secret number is HIGHER than your guess");
                }
                else
                {
                    Console.WriteLine("The secret number is LOWER than your guess");
                }
            }

            if (!hasWon)
            {
                Console.WriteLine("\nYOU LOSE! The secret number is {0}\n\n", secret);
            }
            Console.WriteLine("  Thanks for Playing! \n");
            Console.WriteLine("*********************************************************\n");
        }
    }
}
