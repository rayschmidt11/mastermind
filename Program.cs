using System;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            int turnMax = 10;
            string solution = solutionGenerate();
            bool hasWon;

            gameStartMessage(turnMax);
            hasWon = gameGuessSection(turnMax, solution);
            winLose(hasWon);

        }

   

        static void gameStartMessage(int turnMax) //communicates game rules. displays max turns
        {
            Console.Clear();
            Console.WriteLine("Welcome to Mastermind!");
            Console.WriteLine("The goal of the game is to guess the correct 4 digit number, with all digits between 1 and 6.");
            Console.WriteLine("Don't worry, you'll get some hints along the way. If you see a '+' below a guessed number, you have guessed the right number in the right position.");
            Console.WriteLine("If you see a '-' below your guess, the number is in the solution in a different position.");
            Console.WriteLine("If nothing appears below a number, that number is not in the solution.");
            Console.WriteLine($"You have {turnMax} turns to find the solution!");
        } 

        static bool gameGuessSection(int turnMax, string solution)
        {
            string guess;
            bool hasWon = false; 

            while(turnMax != 0 && !hasWon)
            {
                Console.WriteLine($"{turnMax} rounds remain");
                Console.WriteLine("Please enter a 4 digit number, containing only digits between 1 and 6.");
                guess = Console.ReadLine();

                if (inputValidation(guess))
                {
                    if(guess == solution)
                    {
                        hasWon = true; 
                    }
                    else
                    {
                        checkAnswer(guess, solution);
                        turnMax = turnMax - 1; 
                    }
                }
            }

            return hasWon;
        }

        static string solutionGenerate() // generates the random 4 digit number with digits between 1 and 6.
        {
            Random rand = new Random();
            string solution = rand.Next(1, 6).ToString() + rand.Next(1, 6).ToString() + rand.Next(1, 6).ToString() + rand.Next(1, 6).ToString();

            return solution; 
        }
        static bool inputValidation(string input)// validates the input, checking that it is a  4 digit number, and that all digits are between 1 and 6.
        {
            int number; 
            return input.Length == 4 && int.TryParse(input, out number) && !(input.Contains("0") || input.Contains("7") || input.Contains("8") || input.Contains("9"));
        }

        static void checkAnswer(string toCheck, string solution)// takes the input, checks against the solution, and writes a + or - or ' ' depending on if its contained in the solution. 
        {
            int digit = 0; 

            while(digit != 4)
            {
                if(solution.Contains(toCheck[digit]))
                {
                    if(toCheck[digit] == solution[digit])
                    {
                        Console.Write("+");
                    }
                    else
                    {
                        Console.Write("-");
                    }
                }
                else
                {
                    Console.Write(" ");
                }
                digit += 1;
            }
            Console.WriteLine();
        }

        static void winLose(bool hasWon)
        {
            if (hasWon)
            {
                Console.WriteLine("Congratulations, you have beaten mastermind!");
            }
            else
            {
                Console.WriteLine("Unfortunately, you have lost!");
            }
        } // message determining whether you've won or lost
    }
}
