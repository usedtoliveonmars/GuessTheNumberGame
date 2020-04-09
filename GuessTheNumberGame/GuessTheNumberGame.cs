using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace NumberGuesser
{
    class GuessTheNumberGame
    {
        static void Main()
        {
            GetAppInfo(); //Run function to get app info

            GreetUser(); //Ask user for info

            TheGame(); //Creates the Random number and allows the user to guess the number
        }

        //Get and display app info
        private static void GetAppInfo()
        {
            //Set app vars
            string appName = "Guess The Number Game";
            string appVersion = "1.1.0";
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

            while (true)
            {
                //get user input
                string inputName = Console.ReadLine();

                // check if inputName has special or numbers characters
                var onlyAllowedCharacters = new Regex("^[a-zA-Z]*$");

                //while inputName contains numbers keep asking
                if (onlyAllowedCharacters.IsMatch(inputName) && (!String.IsNullOrEmpty(inputName)))
                {
                    Console.WriteLine("Hi " + inputName);
                    break;
                }

                Console.WriteLine("Please enter a valid name");
            }
        }

        //Create the Game and test the guess
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

                // Make this a method with a return
                // Print success message
                PrintColorMessage(ConsoleColor.Yellow, "Correct! You guessed it!");

                // ask to play again
                while (true)
                {
                    Console.WriteLine("Play Again? {Y or N}");
                    var answer = Console.ReadLine().ToUpper();

                    if (answer == "Y")
                    {
                        Console.Clear();
                        break;
                    }

                    if (answer == "N")
                    {
                        return;
                    }

                    Console.WriteLine("Sorry I didn't recognize that character");
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
