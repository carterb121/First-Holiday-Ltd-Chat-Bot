using System;
using First_Holiday_Ltd_Chat_Bot.Interfaces;

namespace First_Holiday_Ltd_Chat_Bot.Business_Logic
{
    class WelcomePage : IWelcomePage
    {
        public void OpeningGreeting()
        {
            Console.WriteLine("Welcome to First Holiday Ltd! Let's find you your dream holiday!");
            Console.WriteLine("\n");
            Console.WriteLine("I'm going to ask you a series of questions and we will match you with the perfect destination!");
            Console.WriteLine("\n");
            Console.WriteLine("Let's get started!");
            Console.WriteLine("\n");
        }
    }
}
