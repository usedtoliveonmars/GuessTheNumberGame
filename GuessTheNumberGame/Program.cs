using System;

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

            while (true)
            {

                //int correctNumber = 7;

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

                        //keep going
                        continue;
                    }

                    //cast to int and put in guess
                    guess = Int32.Parse(input);

                    // Match guess to correct number
                    if (guess != correctNumber)
                    {
                        // Print error message
                        PrintColorMessage(ConsoleColor.Red, "Wrong number, please try again");
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
        // Get and display app info
        static void GetAppInfo()
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
        static void GreetUser()
        {
            //Start Here
            Console.WriteLine("Welcome to the Number Guesser! \n\nWhat's your name?");

            //get user input
            string inputName = Console.ReadLine();

            Console.WriteLine($"Hello, {inputName}! Lets play the game!");
        }

        //Print color message
        static void PrintColorMessage(ConsoleColor color, string message)
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
