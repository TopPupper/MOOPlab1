using System;
using System.Collections.Generic;
using System.Text;

namespace MOOPlab1
{
    class View
    {
        public static string Error = "The entered number is incorrect.";
        public static string Border = "Please enter number between";
        public void printMessage(string x)
        {
            Console.WriteLine(x);
        }

        public string read()
        {
            return Console.ReadLine();
        }

        public void printHistory(Model game)
        {
            Console.WriteLine("History");
            int NumberOfAttempts = 0;
            foreach (var item in game.History)
            {

                Console.Write("Atttempt number " + (++NumberOfAttempts) + ". Your number: " + item.YourNum + '\n');
            }
        }
    }
}
