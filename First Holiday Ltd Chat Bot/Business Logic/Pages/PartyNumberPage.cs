using System;
using First_Holiday_Ltd_Chat_Bot.Interfaces;

namespace First_Holiday_Ltd_Chat_Bot.Business_Logic.Pages
{
    public class PartyNumberPage : IPartyNumberPage
    {
        private readonly IShared _shared;

        public PartyNumberPage(IShared shared)
        {
            _shared = shared;
        }
        public int PartyNumber_ReturnPartyNumber()
        {
            Console.WriteLine("Thank you!");
            Console.WriteLine("\n");
            Console.WriteLine("Now, please tell us how many people will be traveling.");
            Console.WriteLine("\n");
            Console.WriteLine("Or, to start the application again, please press x...");
            Console.WriteLine("\n");

            var returnValue = PartyNumber_StartScript();
            return returnValue;
        }

        private int PartyNumber_StartScript()
        {
            string stringValue = Console.ReadLine();
            stringValue = stringValue.ToLower().Trim();
            int returnValue = PartyNumber_VerifyUserInput(stringValue);

            return returnValue;
        }

        private int PartyNumber_VerifyUserInput(string userInput)
        {
            int returnValue = 0;

            if (userInput == "x")
            {
                Console.Clear();
                AppStart.Main();
            }
            else 
            {
                try
                {
                    returnValue = Convert.ToInt32(userInput);
                    if (returnValue <= 0)
                    {
                        PartyNumber_ThrowError();
                    }
                }
                catch 
                {
                    PartyNumber_ThrowError();
                }
            }

            return returnValue;
        }

        private void PartyNumber_ThrowError()
        {
            _shared.Shared_Divider();
            Console.WriteLine("I'm sorry, I don't understand your response!");
            Console.WriteLine("\n");
            Console.WriteLine("Please enter a whole number greater than 0");
            Console.WriteLine("\n");
            PartyNumber_StartScript();
        }
    }
}
