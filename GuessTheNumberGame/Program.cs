using System;
using System.Linq;

//Container
namespace NumberGuesser
{
    //Main Class
    class Program
    {
        //Entry Poin Method
        static void Main(string[] args)
        {
            GetAppInfo(); // Run function to get app info

            GreetUser(); //Ask user for info

            TheGame(); //Creates the Random number and allows the user to guess the number
        }


        // Get and display app info
        private static void GetAppInfo()
        {
            //Set app vars
            string appName = "Guess The Number Game";
            string appVersion = "1.0.0";
            string appAurthor = "Chris Cushman";

            //change test color
            Console.ForegroundColor = ConsoleColor.Green;

            //write out app info
            Console.WriteLine("{0}: Version {1} by {2}", appName, appVersion, appAurthor);

            //reset test color
            Console.ResetColor();
        }
        //Ask user name and Greet 
        private static void GreetUser()
        {
            //Start Here
            Console.WriteLine("Welcome to the Number Guesser! \n\nWhat's your name?");

            //get user input
            string inputName = Console.ReadLine();

            // todo - Provide a check for no numbers
            bool containsInt = inputName.Any(char.IsDigit);

            if (containsInt == true)
            {
                Console.WriteLine("You must have some sort of Name!");
            }
            else
            {
                Console.WriteLine($"Hello, {inputName}! Lets play the game!");
            }
        }
        // Create the Game and test the guess
        private static void TheGame()
        {
            while (true)
            {
                // creat a new random object
                Random random = new Random();

                //init correct number
                int correctNumber = random.Next(1, 11);

                //init guess var
                int guess = 0;

                //ask user for number
                Console.WriteLine("Guess a number between 1 and 10");

                // while guess is not correct
                while (guess != correctNumber)
                {
                    // get user input
                    string input = Console.ReadLine();

                    //Make sure its a number
                    if (!int.TryParse(input, out guess))
                    {
                        //Print error message
                        PrintColorMessage(ConsoleColor.Red, "Please use and actual number");

                        continue;
                    }

                    //cast to int and put in guess
                    guess = Int32.Parse(input);

                    // Give the user a hint
                    if (guess > correctNumber)
                    {
                        PrintColorMessage(ConsoleColor.Red, "Lower");
                    }
                    if (guess < correctNumber)
                    {
                        PrintColorMessage(ConsoleColor.Red, "Higher");
                    }
                }
                // Print success message
                PrintColorMessage(ConsoleColor.Yellow, "Correct! You guessed it!");

                // ask to play again
                Console.WriteLine("Play Again? {Y or N}");

                //get answer
                string answer = Console.ReadLine().ToUpper();

                if (answer == "Y")
                {
                    Console.Clear();
                    continue;
                }
                else if (answer == "N")
                {
                    return;
                }
                else
                {
                    return;
                }
            }
        }

        //Print color message
        private static void PrintColorMessage(ConsoleColor color, string message)
        {
            //change test color
            Console.ForegroundColor = color;

            //Tell user its not a number
            Console.WriteLine(message);

            //reset test color
            Console.ResetColor();
        }

    }
}
