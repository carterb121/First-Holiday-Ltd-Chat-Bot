using System;
using First_Holiday_Ltd_Chat_Bot.Interfaces;

namespace First_Holiday_Ltd_Chat_Bot.Business_Logic
{
    public class Shared : IShared
    {
        public void Shared_QuitApplication()
        {
            Console.WriteLine("\n");
            Console.WriteLine("See you next time!");
            Environment.Exit(-1);
        }

        public void Shared_StartSearchOrQuit()
        {
            Console.WriteLine("To start the application, please type: 1");
            Console.WriteLine("To close the application, please type: 2");
            Console.WriteLine("\n");

            string userInput = Console.ReadLine();
            if (userInput.Trim().Equals("1"))
            {
                return;
            }
            else if (userInput.Trim().Equals("2"))
            {
                Shared_QuitApplication();
            }
            else
            {
                Console.WriteLine("I'm sorry, I don't understand your response!");
                Shared_StartSearchOrQuit();
            }
        }

        public void Shared_Divider()
        {
            Console.WriteLine("\n");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("\n");
        }
    }
}
