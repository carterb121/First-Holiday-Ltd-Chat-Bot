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
            Console.WriteLine("\n");

            switch (userInput.Trim())
            {
                case "1":
                    return;
                case "2":
                    Shared_QuitApplication();
                    break;
                default:
                    Console.WriteLine("I'm sorry, I don't understand your response!");
                    Shared_Divider();
                    Shared_StartSearchOrQuit();
                    break;
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
