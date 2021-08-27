/*
 * CSC205 Week7 Programming Assignment #2
 * Tester: Program.cs
 * Source: https://docs.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-console?view=vs-2019
 * 
 * Summarize how the program handles various errors: 
 * 
 * The program uses try-catch blocks to handle potential errors within the program. For example, if a user
 * tries to divide a number by 0, the try statement will output an error message that tells the user that
 * the "operation will reult in a mathematical error." There is a while loop that executes and outputs an
 * error. If the numbers passed are NaN (not a number), then the if-else loop within the try block will execute/display error msg.
 * If a number, character, or symbol other than 'a', 's', 'm', or 'd' is passed in response to the menu option,
 * the same error msg is printed. In short, errors are handled by the program's while loops, and the try-catch
 * block at the end of the Main method.
 * 
 * Would it be a good idea to move the user interface and error-capturing work from the Program class to the Calculator class?

 * In C# I think that placing the user interface code and error-capturing work in the Program class is ok. The Calculator class holds the 
 * majority of the functionality that the program relies on. Having the error-catching and user interface code in the Program class, allows 
 * the user to modify those aspects of the program without affecting (or ruining, in some unfortunate instances) the _core_ of the program.
 * 
 */

using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Display title as the C# console calculator app.
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                // Declare variables and set to empty.
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // Ask the user to type the first number.
                Console.Write("Type a number, and then press Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput1 = Console.ReadLine();
                }

                // Ask the user to type the second number.
                Console.Write("Type another number, and then press Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput2 = Console.ReadLine();
                }

                // Ask the user to choose an operator.
                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.WriteLine("\te - Exponent"); //Add an extra exponent calculation function to the program.
                Console.Write("Your option? ");

                string op = Console.ReadLine();

                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                // Wait for the user to respond before closing.
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing.
            }
            return;
        }
    }
}