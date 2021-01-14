using System;
using System.Collections.Generic;
using First_Holiday_Ltd_Chat_Bot.dto;
using First_Holiday_Ltd_Chat_Bot.Interfaces;


namespace First_Holiday_Ltd_Chat_Bot.Business_Logic
{
    class HolidayTypePage : IHolidayType
    {
        private readonly IDestinationRepository _destinationRepository;
        private readonly IShared _shared;

        public HolidayTypePage(IDestinationRepository destinationRepository, IShared shared)
        {
            _destinationRepository = destinationRepository;
            _shared = shared;
        }

        public List<Destination> HolidayType_ReturnDestinations()
        {
            List<Destination> returnedDestinations = new List<Destination>();
            string userInput = HolidayType_GetUserInput();

            returnedDestinations = GetDestinationsByType(returnedDestinations, userInput);

            return returnedDestinations;
        }

        private string HolidayType_GetUserInput()
        {
            Console.WriteLine("First things first, what kind of holiday are you looking for?");
            Console.WriteLine("\n");
            string userInput = HolidayType_StartScript();

            return userInput;
        }


        private string HolidayType_StartScript()
        {
            Console.WriteLine("Please choose from one of the following options:");
            Console.WriteLine("\n");
            Console.WriteLine("Adventure");
            Console.WriteLine("Beach");
            Console.WriteLine("City");
            Console.WriteLine("Cruise");
            Console.WriteLine("\n");
            Console.WriteLine("Alternatively, to start the application again, please press x...");
            Console.WriteLine("\n");

            string userInput = Console.ReadLine();

            VerifyUserInput(userInput);

            return userInput;
        }

        private void VerifyUserInput(string input)
        {
            input = input.ToLower().Trim();

            switch (input)
            {
                case "adventure":
                    return;
                case "beach":
                    return;
                case "city":
                    return;
                case "cruise":
                    return;
                case "x":
                    Console.Clear();
                    AppStart.Main();
                    break;
                default:
                    _shared.Shared_Divider();
                    Console.WriteLine("I'm sorry, that is not a valid holiday type");
                    Console.WriteLine("\n");
                    HolidayType_StartScript();
                    break;
            }
        }
        private List<Destination> GetDestinationsByType(List<Destination> list, string type)
        {
            _destinationRepository.RetrieveDestinationsByType(list, type);
            return list;
        }
    }
}
