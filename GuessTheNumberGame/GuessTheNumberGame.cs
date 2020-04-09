using System;
using System.Linq;

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

            //get user input
            string inputName = Console.ReadLine();

            // todo - Provide a check for no numbers

            //check if inputName contains any numbers
            bool containsInt = inputName.Any(char.IsDigit);

            //while inputName contains keep asking
            while (containsInt == true)
            {
                Console.WriteLine("You can't have any numbers in your name");

                //user inputs name again
                string nextTry = Console.ReadLine();

                //check for numbers again
                bool testNextTry = nextTry.Any(char.IsDigit);

                //if it doesn't contain numbers break out of loop
                if (testNextTry == false)
                {
                    //if false greet the user
                    Console.WriteLine("Hi " + nextTry);
                    break;
                }
            }         
        }
        //Create the Game and test the guess
        private static void TheGame()
        {
            //Console.WriteLine("What level would you like to play?");
            //Console.WriteLine("Select 1 for 1-10.");
            //Console.WriteLine("Select 2 for 1-20.");
            //Console.WriteLine("Select 3 for 1-30.");

            //string selection = Console.ReadLine();

            //try
            //{
            //    int intSelection = Int32.Parse(selection);

            //    if (intSelection > 3)
            //    {
            //        Console.WriteLine("You must select 1, 2, or 3!");
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message.ToString());
            //}

            //switch (selection)
            //{
            //    case 1:

            //        break;
            //    case 2:

            //        break;
            //    case 3:

            //        break;
            //    default:
            //        Console.WriteLine("You must select a number!");
            //        break;
            //}

            Random();
        }

        private static void Random()
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
